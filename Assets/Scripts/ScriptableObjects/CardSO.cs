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

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(cardId))
        {
            Debug.LogWarning($"[CardSO] - CardId is empty or null on {name}");
        }

        string trimmed = cardId.Trim();

        if (trimmed != cardId)
        {
            Debug.LogWarning($"[CardSO] - Trimming whitespace from CardId on {name}");
        }
        cardId = trimmed.ToLowerInvariant();
    }

    public CardData ToCardData()
    {
        return new CardData
        {
            //Card Charactertiscs
            CardId = this.cardId,
            SlotInBinderPos = this.slotInBinderPos,
            CardName = this.cardName,
            CardRarity = this.cardRarity,
            CardFlavourText = this.cardFlavourText,
            CardPerDayIncome = this.cardPerDayIncome,
            CardSellValue = this.cardSellValue,

            //Card VisualsS
            CardP1Path = cardP1 ? cardP1.name : "",
            CardFramePath = cardFrame ? cardFrame.name : "",
            CardP2Path = cardP2 ? cardP2.name : "",
            CardBgPath = cardBg ? cardBg.name : "",

            //Card Materials
            CardP1MatPath = cardP1Mat ? cardP1Mat.name : "",
            CardFrameMatPath = cardFrameMat ? cardFrameMat.name : "",
            CardP2MatPath = cardP2Mat ? cardP2Mat.name : "",
            CardBgMatPath = cardBgMat ? cardBgMat.name : "",
        };
    }

}
