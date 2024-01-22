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
    /// Логика взаимодействия для ReplaceWindow.xaml
    /// </summary>
    public partial class ReplaceWindow : Window
    {
        public ReplaceWindow(MainWindow mainWindow, string text, string replace, bool matchCase)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            txtSearch.Text = text;
            txtReplace.Text = replace;
            chkMatchCase.IsChecked = matchCase;

            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtSearch.Focus();
        }
        MainWindow mainWindow { get; set; }
        System.Windows.Threading.DispatcherTimer timer;
        private void FindNextCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtSearch.Text.Length > 0;
        }
        private void FindNextCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Find(txtSearch.Text, (bool)chkMatchCase.IsChecked, true);
        }
        private void ReplaceCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtSearch.Text.Length > 0;
        }
        private void ReplaceCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (mainWindow.CanReplace(txtSearch.Text, (bool)chkMatchCase.IsChecked))
            {
                mainWindow.Replace(txtSearch.Text, txtReplace.Text, (bool)chkMatchCase.IsChecked);
            }
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            mainWindow.Find(txtSearch.Text, (bool)chkMatchCase.IsChecked, true);
        }
        private void ReplaceAllCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtSearch.Text.Length > 0;
        }
        private void ReplaceAllCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.ReplaceAll(txtSearch.Text, txtReplace.Text, (bool)chkMatchCase.IsChecked);
        }
    }
}