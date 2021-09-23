using System.Globalization;
using System.Windows;

namespace APIPostsViewer
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            DataContext = Settings.Instance;
        }

        /// <summary>
        /// Initialize controls with current settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            apiURLTextBox.Text = Settings.Instance.API_URL;
            rowsTextBox.Text = Settings.Instance.Rows.ToString();
            columnsTextBox.Text = Settings.Instance.Columns.ToString();
        }

        /// <summary>
        /// Close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Save changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var urlValidation = new UrlValidationRule().Validate(apiURLTextBox.Text, CultureInfo.CurrentCulture);
            if (!urlValidation.IsValid)
                return;

            var gridValidation = new GridValidationRule().Validate(rowsTextBox.Text, CultureInfo.CurrentCulture);
            if (!gridValidation.IsValid)
                return;

            gridValidation = new GridValidationRule().Validate(columnsTextBox.Text, CultureInfo.CurrentCulture);
            if (!gridValidation.IsValid)
                return;

            Settings.Instance.API_URL = apiURLTextBox.Text;
            Settings.Instance.Rows = int.Parse(rowsTextBox.Text);
            Settings.Instance.Columns = int.Parse(columnsTextBox.Text);

            Close();
        }
    }
}