using UnityEngine;
using System.Collections.Generic;

public class BookShelfUI : MonoBehaviour
{
    public static BookShelfUI Instance { get; private set; }

    [SerializeField] private Transform shelfParent;
    [SerializeField] private GameObject BinderSpinePrefab;
    [SerializeField] private SetDatabaseSO setDatabase;
    [SerializeField] private List<Transform> spinesSlots;

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
            Debug.LogWarning("No more slots available");
            return;
        }

        GameObject binderObject = Instantiate(BinderSpinePrefab, spinesSlots[slotIndex]);

        BinderSpineUI binderUI = binderObject.GetComponent<BinderSpineUI>();
        binderUI.Init(set);

        binderSpines[set.SetId] = binderUI;
    }
}
