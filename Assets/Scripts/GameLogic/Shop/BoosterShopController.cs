using UnityEngine;
using System.Collections.Generic;

public class BoosterShopController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private BoosterPackDatabaseSO boosterPackDatabase;
    [SerializeField] private SetDatabaseSO setDatabase;
    [SerializeField] BoosterOpener boosterOpener;
    [SerializeField] BoosterCarouselUI boosterCarouselUI;
    [SerializeField] private OpenedCardsUI openedCardsUI;

    private void Awake()
    {
        //Make databases ready
        boosterPackDatabase.BoosterPacksDictionaryInit();
        setDatabase.SetsDictionaryInit();
    }

    private void Start()
    {
        if (setDatabase == null || boosterPackDatabase == null)
        {
            Debug.LogError("[BoosterShopController] Missing required references.");
            return;
        }

        boosterOpener.Initialize(setDatabase);
        openedCardsUI.CacheInitialize(CacheManager.instance);

        var allBoosters = boosterPackDatabase.GetAllBoosterPacks();
        boosterCarouselUI.Initialize(allBoosters, setDatabase, OnBoosterOpenRequested);
    }

    private void OnBoosterOpenRequested(BoosterPackSO selectedBooster)
    {
        //Open a booster
        List<CardData> openedCards = boosterOpener.RandomCardFromBooster(selectedBooster, 5);

        //Add card to the collection json
        foreach (var card in openedCards)
        {
            //Add the card
            CollectionManager.Instance.Add(card.CardId);

            //Check the Set Progress
            string setId = setDatabase.GetSetIdFromCardId(card.CardId);
            if (!SetProgressManager.Instance.IsUncovered(setId))
            {
                SetProgressManager.Instance.MarkUncovered(setId);
                SetSO set = setDatabase.GetSetById(setId);
                BookShelfUI.Instance.AddBinderToShelf(set);
            }
        }
        //Tell to the UI
        openedCardsUI.ShowOpenedCards(openedCards);
    }
}
