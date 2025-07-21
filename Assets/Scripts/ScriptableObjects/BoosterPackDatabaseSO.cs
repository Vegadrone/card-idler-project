using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New BoosterPackDatabaseSO", menuName = "BoosterPackDatabase/BoosterPackDatabaseSO")]
public class BoosterPackDatabaseSO : ScriptableObject
{
    [SerializeField] List<BoosterPackSO> boosterPackSOInDatabase;

    private Dictionary<string, BoosterPackSO> boosterPackSearch;
    private bool isInitialized = false;

    public void BoosterPacksDictionaryInit()
    {
        if (isInitialized && boosterPackSearch != null) return;

        boosterPackSearch = new Dictionary<string, BoosterPackSO>();
        foreach (var boosterPack in boosterPackSOInDatabase)
        {
            if (!boosterPackSearch.ContainsKey(boosterPack.BoosterPackId))
            {
                boosterPackSearch[boosterPack.BoosterPackId] = boosterPack;
            }
            else
            {
                Debug.LogWarning($"[BoosterPackDatabaseSO] - Duplicate BoosterPackId found: {boosterPack.BoosterPackId}");
            }
        }

        isInitialized = true;
    }

    public BoosterPackSO GetBoosterpackById(string boosterPackId)
    {
        BoosterPacksDictionaryInit();
        boosterPackSearch.TryGetValue(boosterPackId, out var boosterPack);
        return boosterPack;
    }

    public List<BoosterPackSO> GetAllBoosterPacks()
    {
        BoosterPacksDictionaryInit();

        return new List<BoosterPackSO>(boosterPackSearch.Values);
    }

    public void ForceRebuild()
    {
        isInitialized = false;
        BoosterPacksDictionaryInit();
    }
}
