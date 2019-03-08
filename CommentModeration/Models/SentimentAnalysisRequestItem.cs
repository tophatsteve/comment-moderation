using Newtonsoft.Json;

namespace CommentModeration.Models
{
    public class SentimentAnalysisRequestItem
    {
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
