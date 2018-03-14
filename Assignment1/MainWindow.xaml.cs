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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();

        public MainWindow()
        {
            InitializeComponent();
            // Exercise 1 (windows state)
            //WindowState = WindowState.Maximized;
        }
        public override void EndInit()
        {
            base.EndInit();

            // This is one way to do it!
            //uxName.DataContext = user;
            //uxNameError.DataContext = user;

            // This is a better way to do it with less code, since it grabs all user information!
            uxContainer.DataContext = user;
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            isNameOrPasswordBlank();
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            isNameOrPasswordBlank();
        }

        private void isNameOrPasswordBlank()
        {
            if (uxName.Text == string.Empty || uxPassword.Text == string.Empty) { uxSubmit.IsEnabled = false;}
            else { uxSubmit.IsEnabled = true;}          
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);
        }
    }
}
