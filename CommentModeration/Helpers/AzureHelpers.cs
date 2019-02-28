using System;

namespace CommentModeration.Helpers
{
    public static class AzureHelpers
    {
        public static string GetSetting(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
