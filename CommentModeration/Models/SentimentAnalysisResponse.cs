using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommentModeration.Models
{
    public class SentimentAnalysisResponse
    {
        [JsonProperty(PropertyName = "documents")]
        public List<SentimentAnalysisResponseItem> Documents { get; set; }
    }
}
