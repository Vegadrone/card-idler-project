using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class CardCollectionHelper
{
    public static Dictionary<string, int> CountCardInstances(List<CardSO> cards)
    {
        return cards.GroupBy(cards => cards.CardId).ToDictionary(group => group.Key, group => group.Count());
    }

    public static int GetCardCount(List<CardSO> cards, string cardId)
    {
        return cards.Count(card => card.CardId == cardId);
    }
}
