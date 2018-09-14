using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouqDotNet.Models.Metadata
{
    interface IUserMetadata
    {
        [RegularExpression(@"^[a-zA-Z0-9_]+$")]
        [Required]
        [MaxLength(50, ErrorMessage = "Please enter a username between 7 to 50 character ")]
        string Username { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_]+$")]
        [Required]
        [DataType(DataType.Password]
        string Password { get; set; }
    }
    [MetadataType(typeof(IUserMetadata))]
    public partial class User { }
}
