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
    [MetadataType(typeof(ICustomerMetadata))]
    public partial class Customer
    {
        
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}