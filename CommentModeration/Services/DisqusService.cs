using System;
using System.Collections.Generic;
using System.Net.Http;
using CommentModeration.Helpers;
using CommentModeration.Models;
using Newtonsoft.Json;

namespace CommentModeration.Services
{
    public class DisqusService
    {
        public List<DisqusComment> RetrieveComments(DateTime start)
        {
            var comments = new List<DisqusComment>();

            using (var client = new HttpClient())
            {
                var url = BuildRetrieveCommentsUrl(start);
                var result = client.GetAsync(url).Result;

                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync().Result;
                    var parsedContent = JsonConvert.DeserializeObject<DisqusResponse>(content);
                    comments = parsedContent.Response;
                }
            }

            return comments;
        }

        public void ApproveComment(string id)
        {
            var values = BuildApprovalValues(id);
            var url = BuildApproveCommentUrl();

            var content = new FormUrlEncodedContent(values);

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var parsed = response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        private Dictionary<string, string> BuildApprovalValues(string id)
        {
            var accessToken = AzureHelpers.GetSetting("DisqusAccessToken");
            var apiKey = AzureHelpers.GetSetting("DisqusApiKey");
            var appSecret = AzureHelpers.GetSetting("DisqusAppSecret");

            var values = new Dictionary<string, string>
            {
                { "access_token", accessToken },
                { "api_key", apiKey },
                { "api_secret", appSecret },
                { "post", id }
            };

            return values;
        }

        private string BuildApproveCommentUrl()
        {
            var apiBaseUrl = AzureHelpers.GetSetting("DisqusApiBaseUrl");

            return $"{apiBaseUrl}/posts/approve.json";
        }

        private string BuildRetrieveCommentsUrl(DateTime start)
        {
            var apiBaseUrl = AzureHelpers.GetSetting("DisqusApiBaseUrl");
            var forum = AzureHelpers.GetSetting("DisqueForumName");
            var accessToken = AzureHelpers.GetSetting("DisqusAccessToken");
            var apiKey = AzureHelpers.GetSetting("DisqusApiKey");
            var appSecret = AzureHelpers.GetSetting("DisqusAppSecret");
            var unixStartTime = (int)(start.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            return $"{apiBaseUrl}/posts/list.json?start={unixStartTime}&forum={forum}&include=unapproved"
                   + $"&access_token={accessToken}&api_key={apiKey}&api_secret={appSecret}";
        }
    }
}



