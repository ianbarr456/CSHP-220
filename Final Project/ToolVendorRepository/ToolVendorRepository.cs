using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolVendorDB;

namespace ToolVendorRepository
{
    public class ToolVendorModel
    {
        public int InternalId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Designator { get; set; }
        public string Manufacturer { get; set; }
        public double Diameter { get; set; }
        public double FluteLength { get; set; }
        public int FluteNumber { get; set; }
        public string CornerType { get; set; }
        public string Material { get; set; }
        public int? Rake { get; set; }
        public string Link { get; set; }
        public string Notes { get; set; }
        public System.DateTime StockedDate { get; set; }
        public byte[] Image { get; set; }
    }

    public class ToolVendorRepository
    {
        public ToolVendorModel Add(ToolVendorModel ToolVendorModel)
        {
            var ToolVendorDb = ToDbModel(ToolVendorModel);

            DatabaseManager.Instance.Tools.Add(ToolVendorDb);
            DatabaseManager.Instance.SaveChanges();

            ToolVendorModel = new ToolVendorModel
            {
                InternalId = ToolVendorDb.ToolInternalId,
                Type = ToolVendorDb.ToolType,
                Quantity = ToolVendorDb.ToolQuantity,
                Designator = ToolVendorDb.ToolDesignator,
                Manufacturer = ToolVendorDb.ToolManufacturer,
                Diameter = ToolVendorDb.ToolDiameter,
                FluteLength = ToolVendorDb.ToolFluteLength,
                FluteNumber = ToolVendorDb.ToolFluteNumber,
                CornerType = ToolVendorDb.ToolCornerType,
                Material = ToolVendorDb.ToolMaterial,
                Rake = ToolVendorDb.ToolRake,
                Link = ToolVendorDb.ToolLink,
                Notes = ToolVendorDb.ToolNotes,
                StockedDate = ToolVendorDb.ToolStockedDate,
                Image = ToolVendorDb.ToolImage
            };
            return ToolVendorModel;
        }

        public List<ToolVendorModel> GetAll()
        {
            // Use .Select() to map the database Tools to ToolModel
            var items = DatabaseManager.Instance.Tools
              .Select(t => new ToolVendorModel
              {
                  InternalId = t.ToolInternalId,
                  Type = t.ToolType,
                  Quantity = t.ToolQuantity,
                  Designator = t.ToolDesignator,
                  Manufacturer = t.ToolManufacturer,
                  Diameter = t.ToolDiameter,
                  FluteLength = t.ToolFluteLength,
                  FluteNumber = t.ToolFluteNumber,
                  CornerType = t.ToolCornerType,
                  Material = t.ToolMaterial,
                  Rake = t.ToolRake,
                  Link = t.ToolLink,
                  Notes = t.ToolNotes,
                  StockedDate = t.ToolStockedDate,
                  Image = t.ToolImage
              }).ToList();

            return items;
        }
        
        public bool Update(ToolVendorModel toolVendorModel)
        {
            //, ToolVendorModel selectedToolVendor

            var original = DatabaseManager.Instance.Tools.Find(toolVendorModel.InternalId);
            //var original = DatabaseManager.Instance.Tools.Find(selectedToolVendor.InternalId);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(toolVendorModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int toolVendorInternalId)
        {
            var items = DatabaseManager.Instance.Tools
                                .Where(t => t.ToolInternalId == toolVendorInternalId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Tools.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Tool ToDbModel(ToolVendorModel toolVendorModel)
        {
            var toolVendorDb = new Tool
            {
                ToolInternalId = toolVendorModel.InternalId,
                ToolType = toolVendorModel.Type,
                ToolQuantity = toolVendorModel.Quantity,
                ToolDesignator = toolVendorModel.Designator,
                ToolManufacturer = toolVendorModel.Manufacturer,
                ToolDiameter = toolVendorModel.Diameter,
                ToolFluteLength = toolVendorModel.FluteLength,
                ToolFluteNumber = toolVendorModel.FluteNumber,
                ToolCornerType = toolVendorModel.CornerType,
                ToolMaterial = toolVendorModel.Material,
                ToolRake = toolVendorModel.Rake,
                ToolLink = toolVendorModel.Link,
                ToolNotes = toolVendorModel.Notes,
                ToolStockedDate = toolVendorModel.StockedDate,
                ToolImage = toolVendorModel.Image
            };

            return toolVendorDb;
        }
    }
}