using Newtonsoft.Json;
using System.Text;

namespace APIPostsViewer
{
    /// <summary>
    /// API Post
    /// </summary>
    public class Post
    {
        [JsonProperty("userId")]
        public string UserID { get; }

        [JsonProperty("id")]
        public string ID { get; }

        [JsonProperty("title")]
        public string Title { get; }

        [JsonProperty("body")]
        public string Body { get; }

        public Post(string id, string userId, string title, string body)
        {
            ID = id;
            UserID = userId;
            Title = title;
            Body = body;
        }

        /// <summary>
        /// Compile data to string
        /// </summary>
        /// <returns>Result</returns>
        public string CompileContent()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Title);
            sb.AppendLine();
            sb.AppendLine(Body);

            return sb.ToString();
        }
    }
}