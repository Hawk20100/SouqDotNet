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
    [MetadataType(typeof(IOrderMetadata))]
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public char Status { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}