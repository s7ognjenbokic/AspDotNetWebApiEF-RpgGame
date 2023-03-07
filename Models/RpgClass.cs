using System.Text.Json.Serialization;

namespace udemy_dotnet_webapi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
         Mage = 2,
         Healer = 3
    }
}