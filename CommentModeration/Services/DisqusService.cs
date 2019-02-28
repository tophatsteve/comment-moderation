using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
