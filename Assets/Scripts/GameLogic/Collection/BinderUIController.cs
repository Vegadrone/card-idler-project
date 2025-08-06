using System.Collections.Generic;
using UnityEngine;

public class BinderUIController : MonoBehaviour
{

    [SerializeField] private GameObject binderPanel;
    [SerializeField] private BinderUI binderUI;
    

    public void Open()
    {
        binderPanel.SetActive(true);
    }

    public void Close()
    {
        binderPanel.SetActive(false);
    }

    public List<CardSO> GetOwnedCardInSet(SetSO set)
    {
        List<CardSO> setOwnedCard  =  new List<CardSO>(); //Questa lista viene pulita ogni volta che il metoo viene chiamato, meglio qui che fuori perché altrimenti diventerebbe persistente

        foreach (CardSO card in set.CardsInSet)
        {

            int count = CollectionManager.Instance.GetCount(card.CardId);
            Debug.Log($"[BinderUIController] Card: {card.CardId}, Count: {count}");

            if (count > 0) setOwnedCard.Add(card);
        }
        return setOwnedCard;
    }
}

