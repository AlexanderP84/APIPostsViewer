using System;

namespace APIPostsViewer
{
    /// <summary>
    /// Application settings
    /// </summary>
    public class Settings
    {
        private static readonly Lazy<Settings> lazy = new Lazy<Settings>(() => new Settings());

        /// <summary>
        /// API URL
        /// </summary>
        public string API_URL { get; set; }

        /// <summary>
        /// How many rows we should display
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// How many columns we should display
        /// </summary>
        public int Columns { get; set; }

        private Settings()
        {
            API_URL = "https://jsonplaceholder.typicode.com/posts";
            Rows = Columns = 10;
        }

        public static Settings Instance => lazy.Value;
    }
}