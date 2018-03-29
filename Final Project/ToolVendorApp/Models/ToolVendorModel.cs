using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolVendorApp.Models
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

        public ToolVendorRepository.ToolVendorModel ToRepositoryModel()
        {
            var repositoryModel = new ToolVendorRepository.ToolVendorModel
            {
                InternalId = InternalId,
                Type = Type,
                Quantity = Quantity,
                Designator = Designator,
                Manufacturer = Manufacturer,
                Diameter = Diameter,
                FluteLength = FluteLength,
                FluteNumber = FluteNumber,
                CornerType = CornerType,
                Material = Material,
                Rake = Rake,
                Link = Link,
                Notes = Notes,
                StockedDate = StockedDate,
                Image = Image
            };

            return repositoryModel;
        }
        internal ToolVendorModel Clone()
        {
            return (ToolVendorModel)MemberwiseClone();
        }

        public static ToolVendorModel ToModel(ToolVendorRepository.ToolVendorModel respositoryModel)
        {
            var toolVendorModel = new ToolVendorModel
            {
                InternalId = respositoryModel.InternalId,
                Type = respositoryModel.Type,
                Quantity = respositoryModel.Quantity,
                Designator = respositoryModel.Designator,
                Manufacturer = respositoryModel.Manufacturer,
                Diameter = respositoryModel.Diameter,
                FluteLength = respositoryModel.FluteLength,
                FluteNumber = respositoryModel.FluteNumber,
                CornerType = respositoryModel.CornerType,
                Material = respositoryModel.Material,
                Rake = respositoryModel.Rake,
                Link = respositoryModel.Link,
                Notes = respositoryModel.Notes,
                StockedDate = respositoryModel.StockedDate,
                Image = respositoryModel.Image,
            };

            return toolVendorModel;
        }
    }
}
