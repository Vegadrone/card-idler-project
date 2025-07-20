using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BoosterOpener : MonoBehaviour
{
    [SerializeField] private List<SetSO> allSetsFromSetDatabase;

    public List<CardData> RandomCardFromBooster(BoosterPackSO booster, int numberOfCardsInBooster)
    {
        List<CardData> openedCards = new List<CardData>();

        //Take the SetId from BoosterPackSO SetId field, to find at what set the booster belongs.
        string setId = booster.SetId.ToLowerInvariant(); 
        SetSO targetSet = allSetsFromSetDatabase.FirstOrDefault(set => set.SetId.ToLowerInvariant() == setId);

        if (targetSet == null)
        {
            Debug.LogError($"[BoosterOpener] - No SetSO found for SetId: {setId}");
            return openedCards;
        }

        for (int i = 0; i < numberOfCardsInBooster; i++)
        {
            //Take a random rarity for the generated card
            string selectedRarity = RaritySelector.GetRandomRarity();
            var cardsWithRarity = targetSet.CardsInSet.Where(card => card.CardRarity.ToLowerInvariant() == selectedRarity.ToLowerInvariant()).ToList();

            //Filter cards in set by rarity
            if (cardsWithRarity.Count == 0)
            {
                Debug.LogWarning($"[BoosterOpener] No cards found with rarity {selectedRarity} in set {setId}");
                continue;
            }

            //Pick a random card from set
            int index = Random.Range(0, cardsWithRarity.Count);
            CardSO selectedCardSO = cardsWithRarity[index];

            //Convert the card in utilizable Card Data and clone it
            CardData newCard = selectedCardSO.ToCardData();
            CardData finalCard = CardData.CloneWithNewGuid(newCard);

            openedCards.Add(finalCard);
        }
        
        return openedCards;
    }    
}
