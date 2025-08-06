using UnityEngine;

public class BinderSlot : MonoBehaviour
{
    public string slotNumber;
    private GameObject currentCardInstance;

    [SerializeField] private Transform cardAnchor;

    public void SetCard(CardSO card, GameObject cardPrefab, AssetsLoader assetsLoader)
    {
        if (assetsLoader == null)
        {
            Debug.LogError("[BinderSlot - SetCard] AssetsLoader is null! Aborting card display.");
            return;
        }

        if (currentCardInstance != null)
            Destroy(currentCardInstance);

        currentCardInstance = Object.Instantiate(cardPrefab, cardAnchor != null ? cardAnchor : transform);
        Debug.Log($"[BinderSlot - SetCard] Instantiated card prefab for {card.CardId}");
        
        var displayer = currentCardInstance.GetComponent<CardDisplayer>();
        if (displayer != null)
        {
            displayer.DisplayCard(card.ToCardData(), assetsLoader);
        }
        else
        {
            Debug.LogWarning($"[BinderSlot - SetCard] - No CardDisplayer on instantiated card prefab for {card.CardId}");
        }
    }
}
