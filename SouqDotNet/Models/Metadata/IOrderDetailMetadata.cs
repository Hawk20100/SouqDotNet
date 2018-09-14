using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SouqDotNet.Models.Metadata
{
    interface IOrderDetailMetadata
    {
        [Required]
        int Discount { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        decimal NetPrice { get; set; }
        [Required]
        int Quantity { get; set; }
    }

    [MetadataType(typeof(IOrderDetailMetadata))]
    public partial class OrderDetail
    {

    }
}
