using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolVendorDB;

namespace ToolVendorRepository
{
    class DatabaseManager
    {
        private static readonly ToolsEntities entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new ToolsEntities();
            entities.Database.Connection.Open();
        }

        // Provide an accessor to the database
        public static ToolsEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
