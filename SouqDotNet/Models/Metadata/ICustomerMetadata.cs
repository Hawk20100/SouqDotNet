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
    interface ICustomerMetadata
    {
        [DisplayName("#")]
        int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Required]
        [MaxLength(50, ErrorMessage = "less than 50 charterer")]
        [DisplayName("Customer Name")]
        string CustomerName { get; set; }
        [Required]
        [DisplayName("Mobile Number")]
        int Mobile { get; set; }
        [Required]
        [DisplayName("Email Address")]
        [MaxLength(50, ErrorMessage = "less than 50 charterer")]
        [DataType(DataType.EmailAddress)]
        string Email { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "less than 150 charterer")]
        [DisplayName("Customer Address")]
        string Address { get; set; }
    }

    [MetadataType(typeof(ICustomerMetadata))]
    public partial class Customer{}
}
