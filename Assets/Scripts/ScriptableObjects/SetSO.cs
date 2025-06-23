using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetSO", menuName = "IdlerProject/SetSO")]
public class SetSO : ScriptableObject
{
    [SerializeField] List<CardSO> cardsInSet;
    [SerializeField] bool isAvailable;
}
