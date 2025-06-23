using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CardDatabase", menuName = "IdlerProject/CardDatabase")]
public class CardDatabase : ScriptableObject
{
    [SerializeField] List<CardSO> cards;
}
