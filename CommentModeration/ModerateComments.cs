using System;
using CommentModeration.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CommentModeration
{
    public static class ModerateComments
    {
        [FunctionName("ModerateComments")]
        public static void Run([QueueTrigger("comments-for-moderation", Connection = "QueueStorage")]DisqusComment myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
