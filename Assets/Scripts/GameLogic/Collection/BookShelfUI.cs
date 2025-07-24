using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using System;

public class BookShelfUI : MonoBehaviour
{
    public static BookShelfUI Instance { get; private set; }

    [SerializeField] private Transform shelfParent;
    [SerializeField] private GameObject BinderSpinePrefab;
    [SerializeField] private SetDatabaseSO setDatabase;

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

        GameObject binderObject = Instantiate(BinderSpinePrefab, shelfParent);
        BinderSpineUI binderUI = binderObject.GetComponent<BinderSpineUI>();
        binderUI.Init(set);

        binderSpines[set.SetId] = binderUI;
    }
}
