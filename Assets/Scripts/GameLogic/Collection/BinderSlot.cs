using TMPro;
using UnityEngine;

public class BinderSlot : MonoBehaviour
{
    public string slotNumber;
    private GameObject currentCardInstance;
    private GameObject quantityBadge;

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

        UpdateQuantityBadge(card.CardId);
    }

    public void ClearCardSlot()
    {
        if (currentCardInstance != null)
        {
            Destroy(currentCardInstance);
            currentCardInstance = null;
        }
    }
        
    public void UpdateQuantityBadge(string cardId)
    {
        if (currentCardInstance == null) return;

        var quantityText = currentCardInstance.GetComponentInChildren<TextMeshProUGUI>(true);
        quantityBadge = quantityText.transform.parent.gameObject;
        if (quantityText != null)
        {
            int cardCount = CollectionManager.Instance.GetCount(cardId);
            Debug.Log($"[BinderSlot - UpdateQuantityBadge] cardCount for {cardId} = {cardCount}");

            if (cardCount > 1)
            {
                quantityBadge.SetActive(true);
                quantityText.text = $"x{cardCount}";
            }
            else
            {
                quantityBadge.SetActive(false);
            }
        }
    }     
}
