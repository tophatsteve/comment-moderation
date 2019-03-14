using CommentModeration.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CommentModeration
{
    public static class CommentApproval
    {
        [FunctionName("CommentApproval")]
        public static void Run([QueueTrigger("comments-for-approval", Connection = "QueueStorage")]string id, ILogger log)
        {
            var disqusService = new DisqusService();
            disqusService.ApproveComment(id);
        }
    }
}
