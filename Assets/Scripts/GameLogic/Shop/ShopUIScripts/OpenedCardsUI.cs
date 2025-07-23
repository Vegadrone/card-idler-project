using UnityEngine;
using System.Collections.Generic;

public class OpenedCardsUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform openedCardsContainer;
    [SerializeField] private GameObject cardUIPrefab;

    AssetsLoader assetsLoader;

    public void CacheInitialize(CacheManager cacheManager)
    {
        assetsLoader = new AssetsLoader(cacheManager);
    }

     public void ShowOpenedCards(List<CardData> cards)
    {
        if (openedCardsContainer == null)
    {
        Debug.LogError("[BoosterCarouselUI] openedCardsContainer is not assigned.");
        return;
    }
        foreach (Transform child in openedCardsContainer)
        {  
            Destroy(child.gameObject);  
        }

        foreach (var cardData in cards)
        {
            GameObject cardGO = Instantiate(cardUIPrefab, openedCardsContainer);

            CardDisplayer cardDisplayer = cardGO.GetComponent<CardDisplayer>();
            if (cardDisplayer != null)
            {
                cardDisplayer.DisplayCard(cardData, assetsLoader);
            }
            else
            {
                Debug.LogWarning("[BoosterCarouselUI] - Instantiated card prefab is missing CardDisplayer component");
            }
        }
        Debug.Log("[BoosterCarouselUI] - Showing opened cards:");
        foreach (var card in cards)
        {
            Debug.Log($"Card: {card.CardName} - ({card.CardRarity}) | {card.CardInstanceId}");
        }
    }
}
