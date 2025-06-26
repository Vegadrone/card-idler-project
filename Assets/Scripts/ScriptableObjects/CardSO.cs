using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "IdlerProject/NewCard")]
public class CardSO : ScriptableObject
{
    [Header("Card Charateristcs")]
    [SerializeField] private string cardId;
    public string CardId => cardId;
    [SerializeField] private string slotInBinderPos;
    [SerializeField] private string cardName;
     public string CardName => cardName;
    [SerializeField] private string cardRarity;
    [SerializeField] private string cardFlavourText;
    [SerializeField] private long cardPerDayIncome;
    [SerializeField] private long cardSellValue;

     [Header("Card Visuals")]
    [SerializeField] private Sprite cardP1;
    [SerializeField] private Sprite cardFrame;
    [SerializeField] private Sprite cardP2;
    [SerializeField] private Sprite cardBg;

    [Header("Card Materials")]
    [SerializeField] private Material cardP1Mat;
    [SerializeField] private Material cardFrameMat;
    [SerializeField] private Material cardP2Mat;
    [SerializeField] private Material cardBgMat;

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
