using System.Threading.Tasks;
using CommentModeration.Helpers;
using CommentModeration.Models;
using CommentModeration.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CommentModeration
{
    public static class ModerateComments
    {
        [FunctionName("ModerateComments")]
        public static async Task Run([QueueTrigger("comments-for-moderation", Connection = "QueueStorage")]DisqusComment comment,
            [Queue("comments-for-approval", Connection = "QueueStorage")]IAsyncCollector<string> output,
            ILogger log)
        {
            var textAnalysisService = new TextAnalysisService();
            var score = textAnalysisService.GetSentimentAnalysis(comment.Raw_Message);

            var threshold = double.Parse(AzureHelpers.GetSetting("CommentScoreThreshold"));

            if (score > threshold)
            {
                await output.AddAsync(comment.Id);
            }
        }
    }
}
