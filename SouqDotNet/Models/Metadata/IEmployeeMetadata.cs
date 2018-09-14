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
    interface IEmployeeMetadata
    {
        [Required]
        [DisplayName("#")]
        int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Required]
        [DisplayName("Employee Name")]
        [MaxLength(50, ErrorMessage = "less than 50 charterer")]
        string Name { get; set; }
        [Required]
        [DisplayName("Net Salary")]
        [DataType(DataType.Currency)]
        decimal Salary { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Required]
        [DisplayName("Job")]
        [MaxLength(50, ErrorMessage = "less than 50 charterer")]
        string Job { get; set; }
    }

    [MetadataType(typeof(IEmployeeMetadata))]
    public partial class Employee
    {

    }
}
