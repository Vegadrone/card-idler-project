using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoosterPackSO", menuName = "IdlerProject/BoosterPackSO")]
public class BoosterPackSO : ScriptableObject
{
    [Header("BoosterPack Charateristcs")]
    [SerializeField] string boosterPackId;
    public string BoosterPackId => boosterPackId;
    [SerializeField] string setId;
    public string SetId => setId;
   
    [SerializeField] long packCost;

    [Header("BoosterPack Visuals")]
    [SerializeField] Sprite boosterPackImage;

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(boosterPackId))
        {
            Debug.LogWarning($"[BoosterPackSO] - BoosterPackId is empty or null on {name}", this);
        }
        else
        {
            boosterPackId = boosterPackId.Trim().ToLowerInvariant();
        }

        if (string.IsNullOrEmpty(setId))
        {
            Debug.LogWarning($"[BoosterPackSO] SetId is empty or null on {name}", this);
        }
        else
        {
            setId = setId.Trim().ToLowerInvariant();
        }
    }

    public BoosterPackData ToBoosterPackData()
    {
        return new BoosterPackData()
        {
            //Booster Pack Characteristcs
            BoosterPackId = this.boosterPackId,
            SetId = this.setId,
            PackCost = this.packCost,

            //Booster Pack Visuals
            BoosterPackImagePath = boosterPackImage ? boosterPackImage.name : "",
        };
    }
}
