using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Web.Models
{
    public class LaptopDetailsViewModel
    {
        private IEnumerable<CommentViewModel> comments;
        public LaptopDetailsViewModel()
        {
            this.comments = new List<CommentViewModel>();
        }

        public int Id { get; set; }
        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public double MonitorSize { get; set; }

        public int HardDiskSize { get; set; }

        public int RamMemorySize { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}