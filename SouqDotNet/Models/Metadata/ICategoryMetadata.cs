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
    interface ICategoryMetadata
    {
        [DisplayName("#")]
        int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "less than 50 charterer")]
        [DisplayName("Category")]
        string Name { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "less than 250 charterer")]
        string Description { get; set; }
    }

    [MetadataType(typeof(ICategoryMetadata))]
    public partial class Category
    {

    }
}
