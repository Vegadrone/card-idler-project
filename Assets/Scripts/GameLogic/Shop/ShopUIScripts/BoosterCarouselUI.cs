using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Unity.VisualScripting;
public class BoosterCarouselUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image leftBoosterImage;
    [SerializeField] private Image rightBoosterImage;
    [SerializeField] private Image centerBoosterImage;
    [SerializeField] private TextMeshProUGUI boosterNameText;
    [SerializeField] private TextMeshProUGUI boosterPriceText;
    [SerializeField] private Button leftArrowButton;
    [SerializeField] private Button rightArrowButton;
    [SerializeField] private Button openBoosterButton;

    [Header("Opened Cards UI")]
    [SerializeField] private Transform openedCardsContainer;
    [SerializeField] private GameObject cardUIPrefab;

    private List<BoosterPackSO> availableBoosters;
    private SetDatabaseSO setDatabase;
    private System.Action<BoosterPackSO> onBoosterOpen;

    private int currentIndex = 0;
    private AssetsLoader assetsLoader;

    public void Initialize(List<BoosterPackSO> boosters, SetDatabaseSO setDb, System.Action<BoosterPackSO> onOpenCallback)
    {
        availableBoosters = boosters;
        setDatabase = setDb;
        onBoosterOpen = onOpenCallback;

        assetsLoader = new AssetsLoader(CacheManager.instance);

        leftArrowButton.onClick.AddListener(ScrollLeft);
        rightArrowButton.onClick.AddListener(ScrollRight);
        openBoosterButton.onClick.AddListener(OpenBooster);

        _ = UpdateBoosterUI();
    }


    private void ScrollLeft()
    {
        currentIndex = (currentIndex - 1 + availableBoosters.Count) % availableBoosters.Count;
        _ = UpdateBoosterUI();
    }

    private void ScrollRight()
    {
        currentIndex = (currentIndex + 1) % availableBoosters.Count;
        _ = UpdateBoosterUI();
    }

    private async Task UpdateBoosterUI()
    {
        centerBoosterImage.sprite = null;
        leftBoosterImage.sprite = null;
        rightBoosterImage.sprite = null;

        if (availableBoosters == null || availableBoosters.Count == 0) return;

        BoosterPackSO current = availableBoosters[currentIndex];
        BoosterPackSO left = availableBoosters[(currentIndex - 1 + availableBoosters.Count) % availableBoosters.Count];
        BoosterPackSO right = availableBoosters[(currentIndex + 1) % availableBoosters.Count];

        var currentData = current.ToBoosterPackData();
        var leftData = left.ToBoosterPackData();
        var rightData = right.ToBoosterPackData();

        //Load sprites using AssetsLoader with cache support
        Sprite centerSprite = await assetsLoader.LoadSpriteAsync(currentData.BoosterPackImagePath);
        Sprite leftSprite = await assetsLoader.LoadSpriteAsync(leftData.BoosterPackImagePath);
        Sprite rightSprite = await assetsLoader.LoadSpriteAsync(rightData.BoosterPackImagePath);

        centerBoosterImage.sprite = centerSprite;
        leftBoosterImage.sprite = leftSprite;
        rightBoosterImage.sprite = rightSprite;

        centerBoosterImage.color = Color.white;
        leftBoosterImage.color = new Color(1f, 1f, 1f, 0.5f);
        rightBoosterImage.color = new Color(1f, 1f, 1f, 0.5f);

        boosterPriceText.text = $"Buy a pack for: {currentData.PackCost}";

        string setId = current.SetId.ToLowerInvariant();
        string setName = setDatabase.GetSetById(setId)?.SetName;
        boosterNameText.text = setName;
    }

    private void OpenBooster()
    {
        Debug.Log("[BoosterCarouselUI] -  OpenBooster clicked!");
        BoosterPackSO selectedBooster = availableBoosters[currentIndex];
        onBoosterOpen?.Invoke(selectedBooster);
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

        // TODO: Show them in the UI (instantiate prefabs, open animation, etc.)
    }
}
