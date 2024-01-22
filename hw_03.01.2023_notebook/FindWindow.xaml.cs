using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window
    {
        public FindWindow(MainWindow mainWindow, string text, bool matchCase, bool down)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            txtSearch.Text = text;
            chkMatchCase.IsChecked = matchCase;
            radDown.IsChecked = down;
            radUp.IsChecked = !down;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtSearch.Focus();
        }
        MainWindow mainWindow { get; set; }
        private void FindNextCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtSearch.Text.Length > 0;
        }
        private void FindNextCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // starting from boundaries of current selection go up or down
            mainWindow.Find(txtSearch.Text, (bool)chkMatchCase.IsChecked, (bool)radDown.IsChecked);
        }
        
    }
}
