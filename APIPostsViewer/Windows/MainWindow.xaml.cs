using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace APIPostsViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region UI helpers
        /// <summary>
        /// Change mouse cursor
        /// </summary>
        /// <param name="cursor">New cursor</param>
        private void SetMouseCursor(Cursor cursor)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Mouse.OverrideCursor = cursor;
            });
        }

        /// <summary>
        /// Create set of tiles and buttons
        /// </summary>
        /// <param name="posts">Posts</param>
        public void GenerateUI(List<Post> posts)
        {
            postsGrid.Rows = Settings.Instance.Rows;
            postsGrid.Columns = Settings.Instance.Columns;

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i] == null)
                    continue;

                var button = new Button();
                
                AttachPostToButton(button, posts[i]);
                button.Click += UpdateButtonsContent;

                postsGrid.Children.Add(button);
            }
        }

        /// <summary>
        /// Attach post data to button
        /// </summary>
        /// <param name="button">Button</param>
        /// <param name="post">Post</param>
        public void AttachPostToButton(Button button, Post post)
        {
            button.Content = post.ID;
            button.Tag = post;
            button.ToolTip = post.CompileContent();
        }

        /// <summary>
        /// Update buttons content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateButtonsContent(object sender, RoutedEventArgs e)
        {
            foreach (Button button in postsGrid.Children)
            {
                if (button.Tag is Post post)
                    button.Content = (string)button.Content == post.ID ? post.UserID : post.ID;
            }
        }

        /// <summary>
        /// Clear grid
        /// </summary>
        public void ClearUI()
        {
            foreach (Button button in postsGrid.Children)
            {
                button.Click -= UpdateButtonsContent;
            }

            postsGrid.Children.Clear();
        }
        #endregion

        /// <summary>
        /// 'Load Posts' menu handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoadPostsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ClearUI();

            SetMouseCursor(Cursors.Wait);
            var json = await API.GetPostsFromAPIAsync(Settings.Instance.API_URL);
            SetMouseCursor(null);

            var posts = JsonConvert.DeserializeObject<List<Post>>(json);
            GenerateUI(posts);
        }

        /// <summary>
        /// 'Clear Posts' menu handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearPostsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ClearUI();
        }

        /// <summary>
        /// 'Settings' menu handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var settings = new SettingsWindow
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };

            settings.ShowDialog();
        }

        /// <summary>
        /// 'Exit' menu handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
