using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using CommentModeration.Helpers;
using CommentModeration.Models;
using Newtonsoft.Json;

namespace CommentModeration.Services
{
    public class TextAnalysisService
    {
        public double GetSentimentAnalysis(string text)
        {
            var request = BuildRequest(text);
            var response = SendRequest(request);
            return ParseResponse(response);
        }

        private SentimentAnalysisRequest BuildRequest(string text)
        {
            return new SentimentAnalysisRequest
            {
                Documents = new List<SentimentAnalysisRequestItem>
                {
                    new SentimentAnalysisRequestItem
                    {
                        Id = "1",
                        Language = "en",
                        Text = text
                    }
                }
            };
        }

        private SentimentAnalysisResponse SendRequest(SentimentAnalysisRequest request)
        {
            var url = AzureHelpers.GetSetting("CognitiveServicesEndpoint");
            var key = AzureHelpers.GetSetting("CognitiveServicesKey");

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            content.Headers.Add("Ocp-Apim-Subscription-Key", key);

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var parsedResponse = JsonConvert.DeserializeObject<SentimentAnalysisResponse>(responseContent);
                    return parsedResponse;
                }
            }

            return null;
        }

        private double ParseResponse(SentimentAnalysisResponse response)
        {
            if (response == null)
            {
                return 0.0;
            }

            return double.Parse(response.Documents.First().Score);
        }
    }
}
