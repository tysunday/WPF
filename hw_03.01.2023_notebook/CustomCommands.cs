using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace hw_03._01._2023_notebook
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "Exit", "Exit", typeof(MainWindow), new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Alt) }
            );

        public static readonly RoutedUICommand InsertDateTime = new RoutedUICommand
            (
                "Time/Date", "InsertDateTime", typeof(MainWindow), new InputGestureCollection { new KeyGesture(Key.F5, ModifierKeys.None) }
            );

        public static readonly RoutedUICommand FindNext = new RoutedUICommand
            (
                "Find Next", "FindNext", typeof(Window), new InputGestureCollection { new KeyGesture(Key.F3, ModifierKeys.None) }
            );

        public static readonly RoutedUICommand ReplaceAll = new RoutedUICommand
            (
                "Replace All", "ReplaceAll", typeof(ReplaceWindow), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Alt) }
            );

        public static readonly RoutedUICommand About = new RoutedUICommand
            (
                "About", "About", typeof(MainWindow), new InputGestureCollection { }
            );

        public static readonly RoutedUICommand SelectFont = new RoutedUICommand
            (
                "Font", "SelectFont", typeof(MainWindow), new InputGestureCollection { }
            );

        public static readonly RoutedUICommand Goto = new RoutedUICommand
            (
                "Go To", "Goto", typeof(MainWindow), new InputGestureCollection { new KeyGesture(Key.G, ModifierKeys.Control) }
            );

    }
}
