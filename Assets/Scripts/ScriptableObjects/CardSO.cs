using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "IdlerProject/NewCard")]
public class CardSO : ScriptableObject
{
    [SerializeField] string cardId;
    [SerializeField] string slotInBinderPos;
    [SerializeField] string cardName;
    [SerializeField] string cardRarity;
    [SerializeField] string cardFlavourText;
    [SerializeField] long cardPerDayIncome;
    [SerializeField] long cardSellValue;
    [SerializeField] Sprite cardP1;
    [SerializeField] Sprite cardFrame;
    [SerializeField] Sprite cardP2;
    [SerializeField] Sprite cardBg;
    [SerializeField] Material cardP1Mat;
    [SerializeField] Material cardFrameMat;
    [SerializeField] Material cardP2Mat;
    [SerializeField] Material cardBgMat;

    public CardData ToCardData()
    {
        return new CardData
        {
            //Card Charactertiscs
            CardInstanceId = System.Guid.NewGuid().ToString(),
            CardId = this.cardId,
            SlotInBinderPos = this.slotInBinderPos,
            CardName = this.cardName,
            CardRarity = this.cardRarity,
            CardFlavourText = this.cardFlavourText,
            CardPerDayIncome = this.cardPerDayIncome,
            CardSellValue = this.cardSellValue,

            //Card Visuals
            CardP1Path = cardP1 ? cardP1.name : "",
            CardFramePath = cardFrame ? cardFrame.name : "",
            CardP2Path = cardP2 ? cardP2.name : "",
            CardBgPath = cardBg ? cardBg.name : "",

            //Card Materials
            CardP1MatPath = cardP1Mat ? cardP1Mat.name : "",
            CardFrameMatPath = cardFrameMat ? cardFrameMat.name : "",
            CardP2MatPath = cardP2Mat ? cardP2Mat.name : "",
            CardBgMatPath = cardBgMat ? cardBgMat.name : "", 
        } ;
    }

}
