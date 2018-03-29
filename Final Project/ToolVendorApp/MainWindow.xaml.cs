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
using ToolVendorApp.Models;
using System.ComponentModel;
using System.Diagnostics;

namespace ToolVendorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private Adorners.SortAdorner listViewSortAdorner = null;

        public MainWindow()
        {
            InitializeComponent();

            LoadToolVendors();
        }
        private void LoadToolVendors()
        {
            var toolVendors = App.ToolVendorRepository.GetAll();

            uxToolVendorList.ItemsSource = toolVendors
                .Select(t => ToolVendorModel.ToModel(t))
                .ToList();

            // OR
            //var uiContactModelList = new List<ContactModel>();
            //foreach (var repositoryContactModel in contacts)
            //{
            //    This is the .Select(t => ... )
            //    var uiContactModel = ContactModel.ToModel(repositoryContactModel);
            //
            //    uiContactModelList.Add(uiContactModel);
            //}

            //uxContactList.ItemsSource = uiContactModelList;
        }
        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            uxToolVendorList.Items.SortDescriptions.Clear();

            //    var sortDescription = new System.ComponentModel.SortDescription(sortBy);
            //    System.ComponentModel.ListSortDirection.Ascending;
            //    uxContactList.Items.SortDescriptions.Add(sortDescription);

            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxToolVendorList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new Adorners.SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxToolVendorList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        private ToolVendorModel selectedToolVendor;
        private void uxToolVendorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedToolVendor = (ToolVendorModel)uxToolVendorList.SelectedValue;
        }
        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ToolVendorWindow();
            window.setRequiredFieldIconNewForm();
            //window.setRequiredFieldIcon(selectedToolVendor);

            if (window.ShowDialog() == true)
            {
                var uiToolVendorModel = window.ToolVendor;

                var repositoryToolVendorModel = uiToolVendorModel.ToRepositoryModel();

                App.ToolVendorRepository.Add(repositoryToolVendorModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());

                LoadToolVendors();
            }
        }
        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new ToolVendorWindow();
            window.ToolVendor = selectedToolVendor.Clone(); 

            if (window.ShowDialog() == true)
            {
                //, selectedToolVendor.ToRepositoryModel()
                App.ToolVendorRepository.Update(window.ToolVendor.ToRepositoryModel());
                LoadToolVendors();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedToolVendor != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ToolVendorRepository.Remove(selectedToolVendor.InternalId);
            selectedToolVendor = null;
            LoadToolVendors();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedToolVendor != null);
            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;
        }

        private void uxToolVendorList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var window = new ToolVendorWindow();
            //window.ToolVendor = selectedToolVendor;

            //if (window.ShowDialog() == true)
            //{
            //    App.ToolVendorRepository.Update(window.ToolVendor.ToRepositoryModel());
            //    LoadToolVendors();
            //}

            uxFileChange_Click(sender, null);
        }    
    }
}
