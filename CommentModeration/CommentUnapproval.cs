using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CommentModeration
{
    public static class CommentUnapproval
    {
        [FunctionName("CommentUnapproval")]
        public static void Run([QueueTrigger("comments-for-removal", Connection = "QueueStorage")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
