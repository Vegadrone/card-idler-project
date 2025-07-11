using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoosterPackSO", menuName = "IdlerProject/BoosterPackSO")]
public class BoosterPackSO : ScriptableObject
{
    [Header("BoosterPack Charateristcs")]
    [SerializeField] string boosterPackId;
    [SerializeField] string setId;
    public string SetId => setId;
   
    [SerializeField] long packCost;

    [Header("BoosterPack Visuals")]
    [SerializeField] Sprite boosterPackImage;

    public BoosterPackData ToBoosterPackData()
    {
        return new BoosterPackData()
        {
            //Booster Pack Characteristcs
            BoosterId = this.boosterPackId,
            SetId = this.setId,
            PackCost = this.packCost,

            //Booster Pack Visuals
            BoosterPackImagePath = boosterPackImage ? boosterPackImage.name : "",
        };
    }
}
