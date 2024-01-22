using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

// Kudos: http://naracea.com/2011/06/26/selection-highlight-and-focus-on-wpf-textbox/

namespace hw_03._01._2023_notebook
{
    public partial class TextEditor : System.Windows.Controls.TextBox
    {
        public SelectionHighlightAdorner SelectionHighlightAdorner { get; set; }
        public bool ShouldSuppressSelectionHighlightAdorner { get; private set; }

        private void UpdateSelectionHighlightAdorner()
        {
            this.ShouldSuppressSelectionHighlightAdorner = false;
            this.SelectionHighlightAdorner.InvalidateVisual();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (this.SelectionHighlightAdorner != null)
            {
                switch (e.Property.Name)
                {
                    case "FontFamily":
                        this.ShouldSuppressSelectionHighlightAdorner = true;
                        break;
                    case "FontSize":
                        this.ShouldSuppressSelectionHighlightAdorner = true;
                        break;
                    default:
                        this.ShouldSuppressSelectionHighlightAdorner = false;
                        break;
                }
                this.SelectionHighlightAdorner.InvalidateVisual();
            }
        }

        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);
            this.UpdateSelectionHighlightAdorner();
        }

        protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnGotKeyboardFocus(e);
            this.UpdateSelectionHighlightAdorner();
        }

        protected override void OnSelectionChanged(System.Windows.RoutedEventArgs e)
        {
            base.OnSelectionChanged(e);
            this.UpdateSelectionHighlightAdorner();
            e.Handled = true;
        }
    }


    public class SelectionHighlightAdorner : Adorner
    {
        TextEditor _editor;

        public SelectionHighlightAdorner(TextEditor editor)
            : base(editor)
        {
            _editor = editor;
            _editor.SelectionHighlightAdorner = this;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (_editor.SelectionLength > 0 && !_editor.IsKeyboardFocused && !_editor.ShouldSuppressSelectionHighlightAdorner)
            {
                drawingContext.PushClip(new RectangleGeometry(new Rect(0, 0, _editor.ActualWidth, _editor.ActualHeight)));
                int firstCharIndex = _editor.SelectionStart;
                int lastCharIndex = firstCharIndex + _editor.SelectionLength;
                var firstCharRect = _editor.GetRectFromCharacterIndex(firstCharIndex);
                var lastCharRect = _editor.GetRectFromCharacterIndex(lastCharIndex);

                var highlightGeometry = new GeometryGroup();
                if (firstCharRect.Top == lastCharRect.Top)
                {
                    // single line selection
                    highlightGeometry.Children.Add(new RectangleGeometry(new Rect(firstCharRect.TopLeft, lastCharRect.BottomRight)));
                }
                else
                {
                    int firstVisibleLine = _editor.GetFirstVisibleLineIndex();
                    int lastVisibleLine = _editor.GetLastVisibleLineIndex();
                    if (_editor.GetLineIndexFromCharacterIndex(firstCharIndex) < firstVisibleLine)
                    {
                        firstCharIndex = _editor.GetCharacterIndexFromLineIndex(firstVisibleLine - 1);
                        firstCharRect = _editor.GetRectFromCharacterIndex(firstCharIndex);
                    }
                    if (_editor.GetLineIndexFromCharacterIndex(lastCharIndex) > lastVisibleLine)
                    {
                        lastCharIndex = _editor.GetCharacterIndexFromLineIndex(lastVisibleLine + 1);
                        lastCharRect = _editor.GetRectFromCharacterIndex(lastCharIndex);
                    }

                    var lineHeight = firstCharRect.Height;
                    var lineCount = (int)Math.Round((lastCharRect.Top - firstCharRect.Top) / lineHeight);
                    var lineLeft = firstCharRect.Left;
                    var lineTop = firstCharRect.Top;
                    var currentCharIndex = firstCharIndex;
                    for (int i = 0; i <= lineCount; i++)
                    {
                        var lineIndex = _editor.GetLineIndexFromCharacterIndex(currentCharIndex);
                        var firstLineCharIndex = _editor.GetCharacterIndexFromLineIndex(lineIndex);
                        var lineLength = _editor.GetLineLength(lineIndex);
                        var lastLineCharIndex = firstLineCharIndex + lineLength - 1;
                        if (lastLineCharIndex > lastCharIndex)
                        {
                            lastLineCharIndex = lastCharIndex;
                        }
                        var lastLineCharRect = _editor.GetRectFromCharacterIndex(lastLineCharIndex);
                        var lineWidth = lastLineCharRect.Right - lineLeft;
                        if (Math.Round(lineWidth) <= 0)
                        {
                            lineWidth = 5;
                        }
                        highlightGeometry.Children.Add(new RectangleGeometry(new Rect(lineLeft, lineTop, lineWidth, lineHeight)));
                        currentCharIndex = firstLineCharIndex + lineLength;
                        var nextLineFirstCharRect = _editor.GetRectFromCharacterIndex(currentCharIndex);
                        lineLeft = nextLineFirstCharRect.Left;
                        lineTop = nextLineFirstCharRect.Top;
                    }
                }

                drawingContext.PushOpacity(0.4);
                drawingContext.DrawGeometry(SystemColors.HighlightBrush, null, highlightGeometry);
            }
        }
    }
}
