using System;
using System.Collections.Generic;
using CommentModeration.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CommentModeration
{
    public static class ModerateComments
    {
        [FunctionName("ModerateComments")]
        public static void Run([QueueTrigger("comments-for-moderation", Connection = "QueueStorage")]DisqusComment comment, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            var request = new SentimentAnalysisRequest
            {
                Documents = new List<SentimentAnalysisRequestItem>
                {
                    new SentimentAnalysisRequestItem
                    {
                        Id = "1",
                        Language = "en",
                        Text = comment.Raw_Message
                    }
                }
            };
        }
    }
}
