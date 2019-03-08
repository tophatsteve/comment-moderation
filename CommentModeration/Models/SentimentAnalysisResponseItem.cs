using Newtonsoft.Json;

namespace CommentModeration.Models
{
    public class SentimentAnalysisResponseItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "score")]
        public string Score { get; set; }
    }
}
