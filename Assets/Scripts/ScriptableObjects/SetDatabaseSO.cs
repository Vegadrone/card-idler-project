using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SetDatabaseSO", menuName = "IdlerProject/SetDatabaseSO")]
public class SetDatabaseSO : ScriptableObject
{
    [SerializeField] List<SetSO> setsSOInDatabase;

    private Dictionary<string, SetSO> setSearch;

    public void SetsDictionaryInit()
    {
        setSearch = new Dictionary<string, SetSO>();
        foreach (var set in setsSOInDatabase)
        {
            if (setSearch.ContainsKey(set.SetId))
            {
                Debug.LogWarning($"Duplicate SetId found: {set.SetId} — skipping.");
                continue;
            }
            setSearch[set.SetId] = set;
        }
    }

    public SetSO GetSetById(string setId)
    {
        if (setSearch == null)
        {
            SetsDictionaryInit();
        }
        setSearch.TryGetValue(setId, out SetSO set);
        return set;
    }

    public List<string> GetCardIdsFromSet(string setId)
    {
       var set = GetSetById(setId);
       if (set != null)
       {
            return set.CardsInSet.Select(card => card.CardId).ToList();
       }
        return new List<string>();
    }

}
