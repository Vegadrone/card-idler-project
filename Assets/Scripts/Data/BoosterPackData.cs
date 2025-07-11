using System.Collections.Generic;
using Newtonsoft.Json;

public class BoosterPackData
{
    [JsonProperty("boosterPackId")]
    public string BoosterId { get; set; }

    [JsonProperty("setId")]
    public string SetId { get; set; }

    [JsonProperty("packCost")]
    public long PackCost { get; set; }

    [JsonProperty("boosterPackImagePath")]
    public string BoosterPackImagePath { get; set; }
}