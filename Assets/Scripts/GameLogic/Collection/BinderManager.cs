using System.Collections.Generic;
using UnityEngine;

public class BinderManager : MonoBehaviour
{
    [SerializeField] private List<BinderSpineUI> spineButtons; // Assign all spine UI elements here in inspector
    [SerializeField] private BinderUIController binderUIController;
    [SerializeField] private BinderUI binderUI;

    private void Start()
    {
        foreach (BinderSpineUI spine in spineButtons)
        {
            spine.OnClick += HandleBinderSpineClick;
        }
    }

    private void HandleBinderSpineClick(SetSO clickedSet)
    {
        List<CardSO> ownedCards = binderUIController.GetOwnedCardInSet(clickedSet);
        binderUI.DisplayCards(ownedCards);
        binderUIController.Open();
    }
}
