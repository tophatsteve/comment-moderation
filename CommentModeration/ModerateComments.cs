using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CommentModeration
{
    public static class ModerateComments
    {
        [FunctionName("ModerateComments")]
        public static void Run([QueueTrigger("comments-for-moderation", Connection = "QueueStorage")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
