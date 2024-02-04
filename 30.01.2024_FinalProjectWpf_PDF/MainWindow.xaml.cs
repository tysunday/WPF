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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace _30._01._2024_FinalProjectWpf_PDF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelViewPerson modelViewPerson = new ModelViewPerson();

        public MainWindow()
        {
            InitializeComponent();
            var Resume = new Resume();
            Resume.Show();
        }
    }
}
