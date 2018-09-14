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
    interface IDepartmentMetadata
    {
        [DisplayName("#")]
        int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Required]
        [DisplayName("Department Name")]
        [MaxLength(50, ErrorMessage = "less than 50 charterer")]
        string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$")]
        [MaxLength(250, ErrorMessage = "less than 250 charterer")]
        string Description { get; set; }
    }

    [MetadataType(typeof(IDepartmentMetadata))]
    public partial class Department
    {

    }
}
