using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace ZipCodeTextBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string zipCodePattern = @"(^\d{5}(?:[-\s]\d{4})?$)|(^([ABCEGHJKLMNPRSTVXY]|[abceghjklmnprstvxy])[0-9]([ABCEGHJKLMNPRSTVWXYZ]|[abceghjklmnprstvwxyz])[\s]?[0-9]([ABCEGHJKLMNPRSTVWXYZ]|[abceghjklmnprstvwxyz])[0-9]$)";

        public MainWindow()
        {
            InitializeComponent();
            Regex zipCode1 = new Regex(zipCodePattern);
            uxSubmitButton.IsEnabled = false;
        }

        private void uxTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Match zipCode = Regex.Match(uxTextBox.Text, zipCodePattern);
            if (zipCode.Success == true) { uxSubmitButton.IsEnabled = true; }
            else { uxSubmitButton.IsEnabled = false; }
        }

        private void uxTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            uxTextBox.Text = string.Empty;
            uxTextBox.FontStyle = FontStyles.Normal;
            uxTextBox.Foreground = Brushes.Black;
        }
    }
}
