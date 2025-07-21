using UnityEngine;
using System.Collections.Generic;

public class BoosterShopController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private BoosterPackDatabaseSO boosterPackDatabase;
    [SerializeField] private SetDatabaseSO setDatabase;
    [SerializeField] BoosterOpener boosterOpener;
    [SerializeField] BoosterCarouselUI boosterCarouselUI;

    private List<BoosterPackSO> availableBoosters = new List<BoosterPackSO>();

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

        var allBoosters = boosterPackDatabase.GetAllBoosterPacks();
        boosterCarouselUI.Initialize(allBoosters, setDatabase, OnBoosterOpenrequested);
    }


    private void OnBoosterOpenrequested(BoosterPackSO selectedBooster)
    {
        //Open a booster
        List<CardData> openedCards = boosterOpener.RandomCardFromBooster(selectedBooster, 5);

        //Tell to the UI
        boosterCarouselUI.ShowOpenedCards(openedCards);
    }
}
