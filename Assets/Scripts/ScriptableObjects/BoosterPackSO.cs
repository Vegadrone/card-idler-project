using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoosterPackSO", menuName = "IdlerProject/BoosterPackSO")]
public class BoosterPackSO : ScriptableObject
{
     [Header("BoosterPack Charateristcs")]
    [SerializeField] string boosterPackId;
    [SerializeField] List<string> setCardListId;
    [SerializeField] long packCost;

    [Header("BoosterPack Visuals")]
    [SerializeField] Sprite boosterPackImage;

    public BoosterPackData ToBoosterPackData()
    {
        return new BoosterPackData()
        {
            //Booster Pack Characteristcs
            BoosterId = this.boosterPackId,
            SetCardListId = this.setCardListId,
            PackCost = this.packCost,

            //Booster Pack Visuals
            BoosterPackImagePath = boosterPackImage ? boosterPackImage.name : "",
        };
    }
}
