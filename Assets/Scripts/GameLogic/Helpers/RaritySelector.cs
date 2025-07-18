using System;
using System.Collections.Generic;
using System.Linq;

public static class RaritySelector
{
    private static Dictionary<string, int> rarityWeights;
    private static System.Random rng = new System.Random();

    static RaritySelector()
    {
        RarityDictionaryInit();
    }
    public static string GetRandomRarity()
    {
        int totalWeight = rarityWeights.Values.Sum();
        int randomValue = rng.Next(1, totalWeight + 1);
        int cumulative = 0;

        foreach (var rarity in rarityWeights)
        {
            cumulative += rarity.Value;
            if (randomValue <= cumulative)
            {
                return rarity.Key;
            }
        }
        return "common";
    }

    private static void RarityDictionaryInit()
    {
        rarityWeights = new Dictionary<string, int>()
        {
            {"common", 60},
            {"uncommon", 30},
            {"rare", 8},
            {"ultra_rare", 2},
        };
    }

    public static void PrintRarityWeights()
    {
        foreach (var pair in rarityWeights)
        {
            UnityEngine.Debug.Log($"{pair.Key}: {pair.Value}");
        }
    }
}