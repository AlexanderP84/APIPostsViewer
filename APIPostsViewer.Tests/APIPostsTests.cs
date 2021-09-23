using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIPostsViewer.Tests
{
    [TestClass]
    public class APIPostsTests
    {
        [TestMethod]
        public void TestGetOnePostFromAPI()
        {
            var json = API.GetPostsFromAPIAsync("https://jsonplaceholder.typicode.com/posts/1").Result;
            Assert.IsNotNull(json);

            var post = JsonConvert.DeserializeObject<Post>(json);
            Assert.IsNotNull(post);

            Assert.AreEqual(post.ID, "1");
            Assert.AreEqual(post.UserID, "1");
            Assert.AreEqual(post.Title, "sunt aut facere repellat provident occaecati excepturi optio reprehenderit");
            Assert.AreEqual(post.Body, "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto");
        }

        [TestMethod]
        public void TestGetOneHundredPostsFromAPI()
        {
            var json = API.GetPostsFromAPIAsync("https://jsonplaceholder.typicode.com/posts").Result;
            Assert.IsNotNull(json);

            var posts = JsonConvert.DeserializeObject<List<Post>>(json);
            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count, 100);
        }

        [TestMethod]
        public void TestPostCompile()
        {
            var post = new Post("1", "1", "sunt aut facere repellat provident occaecati excepturi optio reprehenderit", "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto");
            var compiledPost = post.CompileContent();
            Assert.IsNotNull(compiledPost);

            var testString = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit" + "\r\n" + "\r\n" + "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto" + "\r\n";
            Assert.AreEqual(compiledPost, testString);
        }
    }
}
