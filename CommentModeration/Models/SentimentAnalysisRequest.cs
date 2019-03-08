using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommentModeration.Models
{
    public class SentimentAnalysisRequest
    {
        [JsonProperty(PropertyName = "documents")]
        public List<SentimentAnalysisRequestItem> Documents { get; set; }
    }
}
