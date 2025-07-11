using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CardDatabase", menuName = "IdlerProject/CardDatabase")]
public class CardDatabaseSO : ScriptableObject
{
    [SerializeField] List<CardSO> cardsInDatabase;

    private Dictionary<string, CardSO> cardSearch;

    public void CardsDictionaryInit()
    {
        cardSearch = new Dictionary<string, CardSO>();
        foreach (var card in cardsInDatabase)
        {
            cardSearch[card.CardId] = card;
        }
    }

    public CardSO GetCardById(string cardId)
    {
        if (cardSearch == null)
        {
            CardsDictionaryInit();
        }

        cardSearch.TryGetValue(cardId, out CardSO card);
        return card;
    }

}
