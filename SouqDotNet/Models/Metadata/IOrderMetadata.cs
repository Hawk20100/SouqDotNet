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
    interface IOrderMetadata
    {
        [DisplayName("#")]
        int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Date")]
        DateTime OrderDate { get; set; }
        [Required]
        [DisplayName("Total Amount")]
        [DataType(DataType.Currency)]
        decimal Total { get; set; }
        [Required]
        char Status { get; set; }
    }

    [MetadataType(typeof(IOrderMetadata))]
    public partial class Order
    {

    }
}
