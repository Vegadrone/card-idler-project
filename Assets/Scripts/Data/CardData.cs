using System;
using Newtonsoft.Json;

public class CardData
{
    //Card Characteristics
    [JsonProperty("cardInstanceId")]
    public string CardInstanceId { get; set; }

    [JsonProperty("cardId")]
    public string CardId { get; set; }

    [JsonProperty("slotInBinderPos")]
    public string SlotInBinderPos { get; set; }

    [JsonProperty("cardName")]
    public string CardName { get; set; }

    [JsonProperty("cardRarity")]
    public string CardRarity { get; set; }

    [JsonProperty("cardFlavourText")]
    public string CardFlavourText { get; set; }

    [JsonProperty("cardPerDayIncome")]
    public long CardPerDayIncome { get; set; }

    [JsonProperty("cardSellValue")]
    public long CardSellValue { get; set; }


    //Card Visuals
    [JsonProperty("cardP1Path")]
    public string CardP1Path { get; set; }

    [JsonProperty("cardFramePath")]
    public string CardFramePath { get; set; }

    [JsonProperty("cardP2Path")]
    public string CardP2Path { get; set; }

    [JsonProperty("cardBgPath")]
    public string CardBgPath { get; set; }

    //Card Materials
    [JsonProperty("cardP1MatPath")]
    public string CardP1MatPath { get; set; }

    [JsonProperty("cardFrameMatPath")]
    public string CardFrameMatPath { get; set; }

    [JsonProperty("cardP2MatPath")]
    public string CardP2MatPath { get; set; }

    [JsonProperty("cardBgMatPath")]
    public string CardBgMatPath { get; set; }

    public static CardData CloneWithNewGuid(CardData original)
    {
        return new CardData()
        {
            CardInstanceId = Guid.NewGuid().ToString(),
            CardId = original.CardId,
            SlotInBinderPos = original.SlotInBinderPos,
            CardName = original.CardName,
            CardRarity = original.CardRarity,
            CardFlavourText = original.CardFlavourText,
            CardPerDayIncome = original.CardPerDayIncome,
            CardSellValue = original.CardSellValue,

            CardP1Path = original.CardP1Path,
            CardFramePath = original.CardFramePath,
            CardP2Path = original.CardP2Path,
            CardBgPath = original.CardBgPath,

            CardP1MatPath = original.CardP1MatPath,
            CardFrameMatPath = original.CardFrameMatPath,
            CardP2MatPath = original.CardP2MatPath,
            CardBgMatPath = original.CardBgMatPath,
        };
    } 
}