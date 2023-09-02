using System.Windows;
using System.Windows.Controls;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : Window
    {
        private MessageBoxResult result = new MessageBoxResult();

        public MessageBox()
        {
            InitializeComponent();
        }
        public MessageBoxResult Show(string title, string Content)
        {
            Message.Text = Content;
            this.Title = title;
            this.ShowDialog();
            return result;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.No;
            this.Close();
        }
    }
}
