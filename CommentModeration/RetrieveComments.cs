using System;
using System.Threading.Tasks;
using CommentModeration.Models;
using CommentModeration.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CommentModeration
{
    public static class RetrieveComments
    {
        [FunctionName("RetrieveComments")]
        public static async Task Run([TimerTrigger("0 0 * * * *")]TimerInfo myTimer,
            [Queue("comments-for-moderation", Connection = "QueueStorage")]IAsyncCollector<DisqusComment> output,
            ILogger log)
        {
            var disqusService = new DisqusService();
            var startTime = DateTime.Now.AddHours(-1);
            var comments = disqusService.RetrieveComments(startTime);

            foreach (var comment in comments)
            {
                await output.AddAsync(comment);
            }

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
