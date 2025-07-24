using System.Collections.Generic;
using Newtonsoft.Json;

public class SetData
{
    [JsonProperty("SetId")]
    public string SetId { get; set; }

    [JsonProperty("SetName")]
    public string SetName { get; set; }

    [JsonProperty("CardInSetIds")]
    public List<string> CardsInSetIds { get; set; } = new List<string>();

    [JsonProperty("Binder Spine Image")]
    public string BinderSpineImage { get; set; }
   
}
