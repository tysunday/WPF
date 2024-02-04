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

namespace _30._01._2024_FinalProjectWpf_PDF
{
    /// <summary>
    /// Логика взаимодействия для Resume.xaml
    /// </summary>
    public partial class Resume : Window
    {
        public Resume()
        {
            InitializeComponent();
            this.DataContext = ((MainWindow)Application.Current.MainWindow).DataContext;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if(pd.ShowDialog() == true)
            {
                IDocumentPaginatorSource idp = FlowDoc;
                pd.PrintDocument(idp.DocumentPaginator, "Flow Document");
            }
        }
    }
}
