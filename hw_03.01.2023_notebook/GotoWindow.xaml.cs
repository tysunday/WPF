using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace hw_03._01._2023_notebook
{
    /// <summary>
    /// Interaction logic for GotoWindow.xaml
    /// </summary>
    public partial class GotoWindow : Window
    {
        public GotoWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            Owner = mainWindow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtLineNumber.Focus();
        }

        public int LineNumber
        {
            get
            {
                return int.Parse(txtLineNumber.Text);
            }
            set
            {
                txtLineNumber.Text = value.ToString();
            }
        }

        private static Regex IsNumeric = new Regex("^[0-9]*$");
        private void txtLineNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric.IsMatch(e.Text);
        }

        private void txtLineNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = txtLineNumber.Text;
            if (!IsNumeric.IsMatch(text))
            {
                // save the current selection start as the replace operation will set it to zero.
                int selectionStart = txtLineNumber.SelectionStart;

                // clear out any non digits
                Regex regex = new Regex("[^0-9]+");
                txtLineNumber.Text = regex.Replace(txtLineNumber.Text, "");

                txtLineNumber.SelectionStart = selectionStart;
            }
        }

        private void btnGoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (Owner as MainWindow).GotoLine(LineNumber - 1);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Notepad.WPF - Goto Line",
                    MessageBoxButton.OK, MessageBoxImage.None);
            }

        }
    }
}
