using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using SouqDotNet.Models.Metadata;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SouqDotNet.Models.Entities
{
    [MetadataType(typeof(IProductMetadata))]
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


        public HttpPostedFileBase FilePhoto { get; set; }
    }

}