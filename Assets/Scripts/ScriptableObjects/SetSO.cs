using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SetSO", menuName = "IdlerProject/SetSO")]
public class SetSO : ScriptableObject
{
    [SerializeField] private string setId;
    public string SetId => setId;

    
    [SerializeField] private string setName;
    public string SetName => setName;

    [SerializeField] private List<CardSO> cardsInSet;
    public List<CardSO> CardsInSet => cardsInSet;

    [SerializeField] bool isAvailable;
    public bool IsAvailable => isAvailable;

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(setId))
        {
            Debug.LogWarning($"[SetSO] - SetId is empty or null on {name}");
        }
        string trimmed = setId.Trim();

        if (trimmed != setId)
        {
            Debug.LogWarning($"[SetSO] - Trimming whitespace from CardId on {name}");
        }
        setId = trimmed.ToLowerInvariant();
    }


    public SetData ToSetData()
    {
        return new SetData
        {
            SetId = this.setId,
            SetName = this.setName,
            CardsInSetIds = cardsInSet.Select(card => card.CardId).ToList(), //Prende ogni carta del set, ne prende l'id e lo mette in una lista
            IsAvailable = this.isAvailable,
        };
    }

}
