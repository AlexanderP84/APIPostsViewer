using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace APIPostsViewer
{
    /// <summary>
    /// API wrapper
    /// </summary>
    public static class API
    {
        /// <summary>
        /// Get posts from API in an async. way
        /// </summary>
        /// <param name="url">API URL</param>
        /// <returns></returns>
        public static async Task<string> GetPostsFromAPIAsync(string url)
        {
            var request = WebRequest.Create(url);
            request.ContentType = "application/json";

            WebResponse response = await request.GetResponseAsync();

            using (Stream stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}