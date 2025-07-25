using UnityEngine;

public class ViewerDebugger : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private string cardId;
    private CardData cardData;
    private AssetsLoader _assetsLoader;

    private void Start()
    {
        _assetsLoader = new AssetsLoader(CacheManager.instance  );
        cardData = CardDatabaseManager.Instance.GetCardSOById(cardId).ToCardData();
        //Debug.Log("This Image is in: " + cardData.CardP1Path);
        cardPrefab = Instantiate(cardPrefab, gameObject.transform);
        CardDisplayer cardDisplayer = cardPrefab.GetComponent<CardDisplayer>();
        cardDisplayer.DisplayCard(cardData, _assetsLoader);
    }
}
