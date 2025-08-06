using System.Collections.Generic;
using UnityEngine;

public class BinderUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> binderSlots = new List<GameObject>();
    [SerializeField] private GameObject cardPrefab;

    private AssetsLoader _assetsLoader;
    private AssetsLoader assetsLoader
    {
        get
        {
            if (_assetsLoader == null)
            {
                if (CacheManager.instance == null)
                {
                    Debug.LogError("[BinderUI - AssetsLoader Getter] CacheManager.instance is null, _assetsLoader not initialized");
                }
                else
                {
                    Debug.Log("[BinderUI - AssetsLoader Getter] _assetsLoader lazily initialized");
                    _assetsLoader = new AssetsLoader(CacheManager.instance);
                }
            }
            return _assetsLoader;
        }
    }

    private Dictionary<string, BinderSlot> slotMap = new();

    private bool isInitialized = false;

    public void BinderSlotInit()
    {
        if (isInitialized) return;

        foreach (GameObject go in binderSlots)
        {
            var slot = go.GetComponent<BinderSlot>();
            if (slot != null && !string.IsNullOrEmpty(slot.slotNumber))
            {
                slotMap[slot.slotNumber] = slot;
                Debug.Log($"[BinderUI - BinderSlotInit] Registered slot: {slot.slotNumber}");
            }
        }

        isInitialized = true;
    }

    public void DisplayCards(List<CardSO> cards)
    {
        Debug.Log($"[BinderUI - Display Cards] Displaying {cards.Count} cards");
        foreach (CardSO card in cards)
        {
            Debug.Log($"[BinderUI - Display Cards] Displaying card {card.CardId} in slot {card.SlotInBinderPos}");
            if (slotMap.TryGetValue(card.SlotInBinderPos, out BinderSlot slot))
            {
                slot.SetCard(card, cardPrefab, assetsLoader);
            }
            else
            {
                Debug.LogWarning($"[BinderUI - Display Cards] - No slot found for {card.CardId} at {card.SlotInBinderPos}");
            }
        }
    }
}
