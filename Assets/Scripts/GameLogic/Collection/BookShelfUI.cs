using UnityEngine;
using System.Collections.Generic;

public class BookShelfUI : MonoBehaviour
{
    public static BookShelfUI Instance { get; private set; }

    [SerializeField] private Transform shelfParent;
    [SerializeField] private GameObject BinderSpinePrefab;
    [SerializeField] private SetDatabaseSO setDatabase;
    [SerializeField] private List<Transform> spinesSlots;
    [SerializeField] private BinderUIController binderUIController;
    [SerializeField] private BinderUI binderUI;

    private Dictionary<string, BinderSpineUI> binderSpines = new Dictionary<string, BinderSpineUI>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        PopulateShelf();
    }

    public void PopulateShelf()
    {
        foreach (var set in setDatabase.GetAllSets())
        {
            if (SetProgressManager.Instance.IsUncovered(set.SetId))
            {
                AddBinderToShelf(set);
            }
        }
    }

    public void AddBinderToShelf(SetSO set)
    {
        if (binderSpines.ContainsKey(set.SetId)) return;

        int slotIndex  = binderSpines.Count;
        if (slotIndex >= spinesSlots.Count)
        {
            Debug.LogWarning("[BookShelfUI - AddBinderToShelf]No more slots available");
            return;
        }

        GameObject binderObject = Instantiate(BinderSpinePrefab, spinesSlots[slotIndex]);

        BinderSpineUI binderUIComponent = binderObject.GetComponent<BinderSpineUI>();
        binderUIComponent.Init(set);

        binderUIComponent.OnClick += (clickedSet) =>
        {
            binderUI.BinderSlotInit();
            var ownedCards = binderUIController.GetOwnedCardInSet(clickedSet);
            binderUI.DisplayCards(ownedCards);
            binderUIController.Open();
        };
    
        binderSpines[set.SetId] = binderUIComponent;
    }
}
