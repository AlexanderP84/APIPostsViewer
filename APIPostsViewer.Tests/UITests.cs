using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Controls;

namespace APIPostsViewer.Tests
{
    [TestClass]
    public class UITests
    {
        [TestMethod]
        public void TestAttachPostToButton()
        {
            var button = new Button();
            var post = new Post("1", "1", "sunt aut facere repellat provident occaecati excepturi optio reprehenderit", "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto");

            MainWindow mw = new MainWindow();
            mw.AttachPostToButton(button, post);

            Assert.AreEqual(button.Content, post.ID);
            Assert.AreEqual(button.Tag, post);
            Assert.AreEqual(button.ToolTip, post.CompileContent());
        }

        [TestMethod]
        public void TestGenerateUI()
        {
            var json = API.GetPostsFromAPIAsync("https://jsonplaceholder.typicode.com/posts").Result;
            var posts = JsonConvert.DeserializeObject<List<Post>>(json);

            MainWindow mw = new MainWindow();
            mw.GenerateUI(posts);

            Assert.AreEqual(mw.postsGrid.Children.Count, 100);
        }

        [TestMethod]
        public void TestUpdateButtonsContent()
        {
            var json = API.GetPostsFromAPIAsync("https://jsonplaceholder.typicode.com/posts").Result;
            var posts = JsonConvert.DeserializeObject<List<Post>>(json);

            MainWindow mw = new MainWindow();
            mw.GenerateUI(posts);

            foreach (Button button in mw.postsGrid.Children)
            {
                Post post = button.Tag as Post;
                Assert.IsNotNull(post);
                Assert.AreEqual(button.Content, post.ID);
            }

            mw.UpdateButtonsContent(mw, new System.Windows.RoutedEventArgs());

            foreach (Button button in mw.postsGrid.Children)
            {
                Post post = button.Tag as Post;
                Assert.IsNotNull(post);
                Assert.AreEqual(button.Content, post.UserID);
            }

            mw.UpdateButtonsContent(mw, new System.Windows.RoutedEventArgs());

            foreach (Button button in mw.postsGrid.Children)
            {
                Post post = button.Tag as Post;
                Assert.IsNotNull(post);
                Assert.AreEqual(button.Content, post.ID);
            }
        }

        [TestMethod]
        public void TestClearUI()
        {
            var json = API.GetPostsFromAPIAsync("https://jsonplaceholder.typicode.com/posts").Result;
            var posts = JsonConvert.DeserializeObject<List<Post>>(json);

            MainWindow mw = new MainWindow();
            mw.GenerateUI(posts);

            mw.ClearUI();
            Assert.AreEqual(mw.postsGrid.Children.Count, 0);
        }
    }
}
