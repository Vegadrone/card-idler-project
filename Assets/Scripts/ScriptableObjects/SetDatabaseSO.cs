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
    private Dictionary<string, string> cardIdToSetId;

    public void SetsDictionaryInit()
    {
        setSearch = new Dictionary<string, SetSO>();
        cardIdToSetId = new Dictionary<string, string>();

        foreach (var set in setsSOInDatabase)
        {
            if (setSearch.ContainsKey(set.SetId))
            {
                Debug.LogWarning($"Duplicate SetId found: {set.SetId} — skipping.");
                continue;
            }
            setSearch[set.SetId] = set;

            foreach (var card in set.CardsInSet)
            {
                if (!cardIdToSetId.ContainsKey(card.CardId))
                {
                    cardIdToSetId[card.CardId] = set.SetId;
                }
                else
                {
                    Debug.LogWarning($"[SetDatabaseSO - SetsDictionaryInit] Duplicate cardId {card.CardId} found in multiple sets.");
                }
            }
        }
    }

    public List<SetSO> GetAllSets()
    {
        if (setSearch == null)
        {
            SetsDictionaryInit();
        }
        return new List<SetSO>(setSearch.Values);
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

    public string GetSetIdFromCardId(string cardId)
    {
        if (cardIdToSetId == null)
        {
            SetsDictionaryInit();
        }

        if (cardIdToSetId.TryGetValue(cardId, out string setId))
        {
            return setId;
        }

        Debug.LogWarning($"[SetDatabaseSO] No Set found for CardId: {cardId}");
        return null;
    }   
}
