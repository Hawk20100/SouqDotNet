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
    interface IProductMetadata
    {
        [DisplayName("#")]
        int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$")]
        [Required]
        [DisplayName("Product Name")]
        [MaxLength(50, ErrorMessage = "less than 50 charterer")]
        string ProductName { get; set; }


        [Required]
        [DisplayName("Unit Price")]
        [DataType(DataType.Currency)]
        decimal Price { get; set; }

        [Required]
        [DisplayName("Units in Stuck")]
        int Quantity { get; set; }

        [MaxLength(250, ErrorMessage = "less than 250 charterer")]
        string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        [DisplayName("Product Photo")]
        string ImageUrl { get; set; }
    }

    [MetadataType(typeof(IProductMetadata))]
    public partial class Product
    {

    }
}
