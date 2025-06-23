using UnityEngine;

[CreateAssetMenu(fileName = "BoosterPackSO", menuName = "IdlerProject/BoosterPackSO")]
public class BoosterPackSO : ScriptableObject
{
    [SerializeField] SetSO setCardList;
    [SerializeField] long packCost;
}
