using System.Collections.Generic;
using UnityEngine;

public class CardDatabaseManager : MonoBehaviour
{
    public static CardDatabaseManager Instance { get; private set; }

    [SerializeField] private CardDatabaseSO cardDatabase;

    private Dictionary<string, CardSO> cardSearch;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        cardDatabase.DictionaryInit();
    }

    public CardSO GetCardSOById(string id)
    {
        return cardDatabase.GetCardById(id);
    }
}
