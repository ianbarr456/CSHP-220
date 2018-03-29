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
using System.Windows.Shapes;
using ToolVendorApp.Models;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Win32;
using System.Data;


namespace ToolVendorApp
{
    /// <summary>
    /// Interaction logic for ToolVendorWindow.xaml
    /// </summary>
    public partial class ToolVendorWindow : Window
    {
        string toolImageLocation = @"C:\Users\uw182c\Documents\Visual Studio 2015\Projects\ToolVendorApp\ToolVendorApp\Images\NoImageDefault.png";
        //Bitmap toolImageLocation = Images.Resource1.NoImageDefault1;
        //string imgLoc = @"../Images/NoImageDefault.jpg";
        //string imgLoc = "";
        string requiredFieldImgLoc = @"C:\Users\uw182c\documents\visual studio 2015\Projects\ToolVendorApp\ToolVendorApp\Images\ExclamationMark.jpg";
        //Bitmap requiredFieldImgLoc = Images.Resource1.ExclamationMark;
        SqlConnection conn = new SqlConnection();
        SqlCommand command;
        BitmapImage bitmap = new BitmapImage();
        Dictionary<TextBox, Image> dictionary = new Dictionary<TextBox, Image>();
        bool submitButtonModify = false;
        byte[] toolImage;

        public ToolVendorWindow()
        {
            InitializeComponent();


            dictionary.Add(uxQuantity, uxRequiredImage1);
            dictionary.Add(uxDesignator, uxRequiredImage2);
            dictionary.Add(uxManufacturer, uxRequiredImage3);
            dictionary.Add(uxDiameter, uxRequiredImage4);
            dictionary.Add(uxFluteLength, uxRequiredImage5);
            dictionary.Add(uxFluteNumber, uxRequiredImage6);
            dictionary.Add(uxCornerType, uxRequiredImage7);
            dictionary.Add(uxMaterial, uxRequiredImage8);
            dictionary.Add(uxRake, uxRequiredImage9);         

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(requiredFieldImgLoc, UriKind.Absolute);
            bitmap.EndInit();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        private void uxBrowse_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image files (*.png, *.jpg, *.gif, *.bmp)|*.png;*.jpg;*.gif;*.bmp|All Files (*.*)|*.*";
                ofd.Title = "Select Tool Picture";
                if (ofd.ShowDialog() == true)
                {
                    toolImage = null;
                    toolImageLocation = ofd.FileName.ToString();
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(toolImageLocation, UriKind.Absolute);
                    bitmap.EndInit();

                    uxToolImage.Source = bitmap;
                    uxNullImage.Visibility = Visibility.Hidden;

                    FileStream fs = new FileStream(toolImageLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    toolImage = br.ReadBytes((int)fs.Length);
                    ToolVendor.Image = toolImage;
                }
                else
                {
                    ToolVendor.Image = ToolVendor.Image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            
        }
        public ToolVendorModel ToolVendor { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            //byte[] toolImage = null;
            ////try
            ////{               
            //FileStream fs = new FileStream(toolImageLocation, FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(fs);
            //toolImage = br.ReadBytes((int)fs.Length);


            //string sql = "Insert into TOOL(X,Y,IMAGE)VALUES("+text+
            //if (conn.State != ConnectionState.Open) { conn.Open(); }               
            //command = new SqlCommand(SqlParameter("@img",img));
            //int x = command.ExecuteNonQuery();
            conn.Close();
            //MessageBox.Show(x.ToString() + " record(s) saved.");

            //}
            //catch (Exception ex)
            //{
            //    conn.Close();
            //    MessageBox.Show(ex.Message);
            //}


            //ToolVendor.Type = uxType.Text;
            if (uxMill.IsChecked.Value)
            {
                ToolVendor.Type = "Mill";
            }
            else
            {
                ToolVendor.Type = "Lathe";
            }

            ToolVendor.Quantity = Convert.ToInt32(uxQuantity.Text);
            ToolVendor.Designator = uxDesignator.Text;
            ToolVendor.Manufacturer = uxManufacturer.Text;
            ToolVendor.Diameter = Convert.ToDouble(uxDiameter.Text);
            ToolVendor.FluteLength = Convert.ToDouble(uxFluteLength.Text);
            ToolVendor.FluteNumber = Convert.ToInt32(uxFluteNumber.Text);
            ToolVendor.CornerType = uxCornerType.Text;
            ToolVendor.Material = uxMaterial.Text;
            ToolVendor.Rake = Convert.ToInt32(uxRake.Text);
            ToolVendor.Link = uxLink.Text;
            ToolVendor.Notes = uxNotes.Text;
            ToolVendor.StockedDate = DateTime.Now;
            ToolVendor.Image = toolImage;

            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ToolVendor != null)
            {
                if (ToolVendor.Type == "Mill") { uxMill.IsChecked = true; }
                else { uxLathe.IsChecked = true; }

                if (ToolVendor.Image != null) { uxNullImage.Visibility = Visibility.Hidden; }
                else { uxNullImage.Visibility = Visibility.Visible; }               

                uxSubmit.Content = "Update";
            }
            else
            {
                ToolVendor = new ToolVendorModel();
                ToolVendor.StockedDate = DateTime.Now;
            }
            toolImage = ToolVendor.Image;
            uxGrid.DataContext = ToolVendor;
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (sender.GetType() != typeof(Hyperlink))
                return;
            string link = ((Hyperlink)sender).NavigateUri.ToString();
            Process.Start(link);
        }

        private void IntegerValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text[0]))
            {
                e.Handled = false; // process the input
            }
            else
            {
                e.Handled = true; // ignore the input
            }
        }

        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //public void setRequiredFieldIcon()
            Regex regex = new Regex(@"^(\d{0,2})([\.]\d{0,3})?$");
            if (char.IsDigit(e.Text[0]))
            {
                string textBoxText = ((TextBox)sender).Text + e.Text[0];
                //MessageBox.Show(textBoxText);
                if (regex.IsMatch(textBoxText)) { e.Handled = false; }
                else { e.Handled = true; }
            }
            else if (e.Text == ".")
            {
                string textBoxText = ((TextBox)sender).Text + e.Text[0];
                //MessageBox.Show(textBoxText);
                if (regex.IsMatch(textBoxText)) { e.Handled = false; }
                else { e.Handled = true; }
            }
            else
            {
                e.Handled = true; // ignore the input
            }
        }
        public void setRequiredFieldIconNewForm()
        {
            bitmap.UriSource = new Uri(requiredFieldImgLoc, UriKind.Absolute);

            uxRequiredImage1.Source = bitmap;
            uxRequiredImage2.Source = bitmap;
            uxRequiredImage3.Source = bitmap;
            uxRequiredImage4.Source = bitmap;
            uxRequiredImage5.Source = bitmap;
            uxRequiredImage6.Source = bitmap;
            uxRequiredImage7.Source = bitmap;
            uxRequiredImage8.Source = bitmap;
            uxRequiredImage9.Source = bitmap;
        }
        public void setRequiredFieldIcon(object textBox)
        {

            TextBox callingTextBox = ((TextBox)textBox);
            //if (dictionary.ContainsKey(((TextBox)textBox))

            if (string.IsNullOrEmpty(callingTextBox.Text))
            {
                dictionary[callingTextBox].Source = bitmap;
                dictionary[callingTextBox].Visibility = Visibility.Visible;
                uxSubmit.IsEnabled = false;
                //submitButtonModify = isFieldValid();
                //if (submitButtonModify == true) { uxSubmit.IsEnabled = true; }
                //else { uxSubmit.IsEnabled = false; }
            }
            else
            {
                dictionary[callingTextBox].Source = bitmap;
                dictionary[callingTextBox].Visibility = Visibility.Hidden;
                submitButtonModify = isFieldValid();
                if (submitButtonModify == true) { uxSubmit.IsEnabled = true; }
                else { uxSubmit.IsEnabled = false; }
            }
        }
        private bool isFieldValid()
        {
            if (string.IsNullOrEmpty(uxQuantity.Text) || string.IsNullOrWhiteSpace(uxQuantity.Text)) { return false; }
            else if (string.IsNullOrEmpty(uxDesignator.Text) || string.IsNullOrWhiteSpace(uxDesignator.Text)) { return false; }
            else if (string.IsNullOrEmpty(uxManufacturer.Text) || string.IsNullOrWhiteSpace(uxManufacturer.Text)) { return false; }
            else if (string.IsNullOrEmpty(uxDiameter.Text) || string.IsNullOrWhiteSpace(uxDiameter.Text)) { return false; }
            else if (string.IsNullOrEmpty(uxFluteLength.Text) || string.IsNullOrWhiteSpace(uxFluteLength.Text)) { return false; }
            else if (string.IsNullOrEmpty(uxFluteNumber.Text) || string.IsNullOrWhiteSpace(uxFluteNumber.Text)) { return false; }
            else if (string.IsNullOrEmpty(uxCornerType.Text) || string.IsNullOrWhiteSpace(uxCornerType.Text)) { return false; }
            else if (string.IsNullOrEmpty(uxMaterial.Text) || string.IsNullOrWhiteSpace(uxMaterial.Text)) { return false; }
            else if (string.IsNullOrEmpty(uxRake.Text) || string.IsNullOrWhiteSpace(uxRake.Text)) { return false; }
            else { return true; }
        }

        private void setRequiredFieldIconTrigger(object sender, RoutedEventArgs e)
        {
            setRequiredFieldIcon(sender);
        }
    }
}
