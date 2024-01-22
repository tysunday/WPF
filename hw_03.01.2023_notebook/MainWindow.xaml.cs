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
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace hw_03._01._2023_notebook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            SearchMatchCase = false;
            SearchDown = true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtEditor = new TextEditor();
            textEditorHolder.Children.Add(txtEditor);
            var layer = System.Windows.Documents.AdornerLayer.GetAdornerLayer(txtEditor);
            SelectionHighlightAdorner txtEditorAdorner = new SelectionHighlightAdorner(txtEditor);
            layer.Add(txtEditorAdorner);

            txtEditor.AcceptsReturn = true;
            txtEditor.AcceptsTab = true;
            txtEditor.TextChanged += txtEditor_TextChanged;
            txtEditor.SelectionChanged += txtEditor_SelectionChanged;

            txtEditor.Focus();
        }

        public TextEditor txtEditor { get; private set; }
        public string FilePath { get; private set; }
        public string FileName
        {
            get
            {
                return string.IsNullOrEmpty(FilePath)
                    ? "Untitled"
                    : System.IO.Path.GetFileName(FilePath);
            }
        }
        public string WindowTitle
        {
            get
            {
                return FileName + " - Notepad.WPF";
            }
        }
        public bool Dirty { get; private set; }

        public string SearchText { get; private set; }
        public string SearchReplace { get; private set; }
        public bool SearchMatchCase { get; private set; }
        public bool SearchDown { get; private set; }

        public bool WordWrap
        {
            get
            {
                return (txtEditor != null) && (txtEditor.TextWrapping == TextWrapping.Wrap);
            }
            set
            {
                if (value)
                {
                    scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    txtEditor.TextWrapping = TextWrapping.Wrap;
                }
                else
                {
                    scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    txtEditor.TextWrapping = TextWrapping.NoWrap;
                }
            }
        }
        public bool StatusBar
        {
            get
            {
                return stsBar.Visibility != System.Windows.Visibility.Collapsed;
            }
            set
            {
                stsBar.Visibility = value ?
                    System.Windows.Visibility.Visible :
                    System.Windows.Visibility.Collapsed;

                if (value) { UpdateStatusBarText(); }
            }
        }

        private void txtEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            Dirty = true;
        }

        void UpdateStatusBarText()
        {
            int line = txtEditor.GetLineIndexFromCharacterIndex(txtEditor.SelectionStart);
            int lineStart = txtEditor.GetCharacterIndexFromLineIndex(line);
            int col = txtEditor.SelectionStart - lineStart;
            stsText.Text = string.Format("Line {0}, Col {1}", line + 1, col + 1);
        }
        void txtEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (StatusBar)
            {
                UpdateStatusBarText();
            }
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtEditor.Text = "";
            FilePath = null;
            Dirty = false;
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Text Files|*.txt"
            };
            if (dlg.ShowDialog() == true)
            {
                FilePath = dlg.FileName;
                txtEditor.Text = File.ReadAllText(FilePath);
                Dirty = false;
            }
        }

        private void PrintCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PrintCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            if (dlg.ShowDialog() == true)
            {
                FlowDocument doc = new FlowDocument();

                doc.Blocks.Add(new Paragraph(new Run(txtEditor.Text)));
                doc.PageHeight = dlg.PrintableAreaHeight;
                doc.PageWidth = dlg.PrintableAreaWidth;
                doc.PagePadding = new Thickness(15);
                doc.ColumnGap = 0;
                doc.ColumnWidth = doc.PageWidth - (doc.PagePadding.Left + doc.PagePadding.Right);
                doc.FontFamily = txtEditor.FontFamily;
                doc.FontSize = txtEditor.FontSize;
                doc.FontStretch = txtEditor.FontStretch;
                doc.FontStyle = txtEditor.FontStyle;
                doc.FontWeight = txtEditor.FontWeight;
                dlg.PrintDocument((doc as IDocumentPaginatorSource).DocumentPaginator, WindowTitle);
            }
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Save()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                SaveFileDialog dlg = new SaveFileDialog
                {
                    Filter = "Text Files|*.txt",
                    OverwritePrompt = true
                };
                if (dlg.ShowDialog() == true)
                {
                    FilePath = dlg.FileName;
                    File.WriteAllText(FilePath, txtEditor.Text);
                    Dirty = false;
                }
            }
            else
            {
                File.WriteAllText(FilePath, txtEditor.Text);
                Dirty = false;
            }
        }
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Save();
        }

        private void SaveAsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "Text Files|*.txt",
                OverwritePrompt = true
            };
            if (dlg.ShowDialog() == true)
            {
                FilePath = dlg.FileName;
                File.WriteAllText(FilePath, txtEditor.Text);
                Dirty = false;
            }
        }

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private bool SaveOnExit()
        {
            string name = string.IsNullOrEmpty(FilePath) ? "Untitled" : FilePath;
            MessageBoxResult result = MessageBox.Show(
                "Would you like to save changes to " + name + "?",
                "Notepad.WPF",
                MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Save();
                    return !Dirty;
                case MessageBoxResult.No:
                    return true;
                case MessageBoxResult.Cancel:
                    return false;
            }
            return true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Dirty)
            {
                if (!SaveOnExit())
                {
                    // Cancelled or didn't save
                    return;
                }

                // In the case of "No - Don't Save" Mark the document as clean so the Window_Closing 
                // handler will not need to ask again
                Dirty = false;
            }

            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Dirty)
            {
                if (!SaveOnExit())
                {
                    // Cancelled or didn't save
                    e.Cancel = true;
                }
            }
        }

        private void DeleteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtEditor.SelectionLength > 0;
        }

        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtEditor.SelectedText = "";
        }

        private void InsertDateTimeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void InsertDateTimeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtEditor.SelectedText = DateTime.Now.ToString();
        }

        private bool FindNext()
        {
            string text = txtEditor.Text;

            StringComparison comparison = SearchMatchCase
                ? StringComparison.CurrentCulture
                : StringComparison.CurrentCultureIgnoreCase;

            int index;
            if (SearchDown)
            {
                int start = txtEditor.SelectionStart + txtEditor.SelectionLength;
                index = text.IndexOf(SearchText, start, comparison);
            }
            else
            {
                int start = txtEditor.SelectionStart;
                index = text.LastIndexOf(SearchText, start, comparison);
            }

            if (index >= 0)
            {
                txtEditor.SelectionStart = index;
                txtEditor.SelectionLength = SearchText.Length;
                return true;
            }
            else
            {
                MessageBox.Show("Cannot find \"" + SearchText + "\"", "Notepad.WPF", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
        public void Find(string search, bool matchCase, bool down)
        {
            SearchText = search;
            SearchMatchCase = matchCase;
            SearchDown = down;

            FindNext();
        }

        private void FindCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void FindCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FindWindow dlg = new FindWindow(this, SearchText, SearchMatchCase, SearchDown);
            dlg.ShowDialog();
        }

        private void FindNextCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(SearchText);
        }

        private void FindNextCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FindNext();
        }

        public bool CanReplace(string search, bool matchCase)
        {
            StringComparer comparer = StringComparer.Create(System.Globalization.CultureInfo.CurrentCulture, !matchCase);
            return comparer.Compare(search, txtEditor.SelectedText) == 0;
        }
        public void Replace(string search, string replace, bool matchCase)
        {
            SearchText = search;
            SearchReplace = replace;
            SearchMatchCase = matchCase;

            if (CanReplace(search, matchCase))
            {
                int index = txtEditor.SelectionStart;
                txtEditor.SelectedText = replace;
            }
        }

        public void ReplaceAll(string search, string replace, bool matchCase)
        {
            SearchText = search;
            SearchReplace = replace;
            SearchMatchCase = matchCase;

            txtEditor.Text = Regex.Replace(txtEditor.Text, search, replace, RegexOptions.IgnoreCase);
        }

        private void ReplaceCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ReplaceCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ReplaceWindow dlg = new ReplaceWindow(this, SearchText, SearchReplace, SearchMatchCase);
            dlg.ShowDialog();
        }

        private void HelpCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void HelpCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://windows.microsoft.com/en-us/windows/notepad-faq");
        }

        private void AboutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AboutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Notepad.WPF - written using WPF and C#", "Notepad.WPF", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SelectFontCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SelectFontCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Drawing.FontStyle style = System.Drawing.FontStyle.Regular;
            if ((txtEditor.FontWeight == FontWeights.SemiBold) ||
                (txtEditor.FontWeight == FontWeights.Bold) ||
                (txtEditor.FontWeight == FontWeights.Heavy) ||
                (txtEditor.FontWeight == FontWeights.ExtraBlack) ||
                (txtEditor.FontWeight == FontWeights.ExtraBold) ||
                (txtEditor.FontWeight == FontWeights.DemiBold) ||
                (txtEditor.FontWeight == FontWeights.UltraBold))
            {
                style = style | System.Drawing.FontStyle.Bold;
            }
            if (txtEditor.FontStyle == FontStyles.Italic)
            {
                style = style | System.Drawing.FontStyle.Italic;
            }

            System.Drawing.Font font = new System.Drawing.Font(txtEditor.FontFamily.ToString(), (float)txtEditor.FontSize, style);

            System.Windows.Forms.FontDialog dlg = new System.Windows.Forms.FontDialog
            {
                Font = font
            };
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtEditor.FontFamily = new FontFamily(dlg.Font.Name);
                txtEditor.FontSize = dlg.Font.Size;
                txtEditor.FontWeight = dlg.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                txtEditor.FontStyle = dlg.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
            }
        }

        private void GotoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !WordWrap;
        }

        public void GotoLine(int line)
        {
            if ((line < 0) || (line >= txtEditor.LineCount))
            {
                throw new Exception("The line number is beyond the total number of lines");
            }

            txtEditor.SelectionLength = 0;
            txtEditor.SelectionStart = txtEditor.GetCharacterIndexFromLineIndex(line);
        }
        private void GotoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GotoWindow dlg = new GotoWindow(this);
            dlg.ShowDialog();
        }
    }
}
