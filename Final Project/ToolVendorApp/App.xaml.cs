using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ToolVendorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ToolVendorRepository.ToolVendorRepository toolVendorRepository;

        static App()
        {
            toolVendorRepository = new ToolVendorRepository.ToolVendorRepository();
        }

        public static ToolVendorRepository.ToolVendorRepository ToolVendorRepository
        {
            get
            {
                return toolVendorRepository;
            }
        }

    }
}
