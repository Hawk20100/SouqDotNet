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
    [MetadataType(typeof(IOrderDetailMetadata))]
    public partial class OrderDetail
    {
        [Key]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Discount { get; set; }
        public decimal NetPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}