using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class CollectionManager
{
    private Dictionary<string, int> ownedCards = new Dictionary<string, int>();

    private string saveFilePath;

    private static CollectionManager _instance;
    public static CollectionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CollectionManager();
                _instance.CollectionManagerInit();
            }
            return _instance;
        }
    }

    public void CollectionManagerInit()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "collection.json");
        Load();
    }

    private void Load()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning($"[CollectionManager - Load] - {saveFilePath} not found!");
            return;
        }
        string json = File.ReadAllText(saveFilePath);
        ownedCards = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
        Debug.LogWarning($"[CollectionManager - Load] - {saveFilePath} loaded!");
    }

    private void Save()
    {
        string json = JsonConvert.SerializeObject(ownedCards, Formatting.Indented);
        File.WriteAllText(saveFilePath, json);
        Debug.LogWarning($"[CollectionManager - Save] - {saveFilePath} saved!");
    }

    public void Add(string cardId, int amount = 1)
    {
        if (string.IsNullOrEmpty(cardId))
        {
            Debug.LogWarning($"[CollectionManager - Add] - Tried to add a card but CardId was empty or null!");
            return;
        }

        if (amount <= 0)
        {
            Debug.LogWarning($"[CollectionManager - Add] - Tried to add a card with a non positive amount!");
            return;
        }

        if (ownedCards.ContainsKey(cardId))
        {
            ownedCards[cardId] += amount;
        }
        else
        {
            ownedCards[cardId] = amount;
        }
        Save();
    }
    public void RemoveCard(string cardId, int amount = 1)
    {
        if (string.IsNullOrEmpty(cardId))
        {
            Debug.LogWarning($"[CollectionManager - Remove] - Tried to remove a card but CardId was empty or null!");
            return;
        }
        if (amount <= 0)
        {
            Debug.LogWarning($"[CollectionManager - Remove] - Tried to remove a card with a non positive amount!");
            return;
        }
        if (ownedCards.ContainsKey(cardId))
        {
            ownedCards[cardId] -= amount;

            if (ownedCards[cardId] <= 0)
            {
                ownedCards.Remove(cardId);
                Debug.Log($"[CollectionManager - Remove] - Removed all copies of cardId: {cardId}");
            }
            else
            {
                Debug.Log($"[CollectionManager - Remove] - Decreased count of {cardId} to {ownedCards[cardId]}");
            }
            Save();
        }
        else
        {
            Debug.LogWarning($"[CollectionManager - Remove] - Tried to remove cardId '{cardId}' but it's not in the collection.");

        }
    }

    public int GetCount(string cardId)
    {
        if (string.IsNullOrEmpty(cardId))
        {
            Debug.LogWarning($"[CollectionManager - GetCount] - Tried to get count of {cardId} but it was null or empty");
            return 0;
        }
        if (ownedCards.TryGetValue(cardId, out int count))
        {
            return count;
        }
        return 0;
    }
}

