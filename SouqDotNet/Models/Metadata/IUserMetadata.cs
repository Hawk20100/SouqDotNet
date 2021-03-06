﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouqDotNet.Models.Metadata
{
    interface IUserMetadata
    {

        [Required]
        [DisplayName("")]
        [DataType(DataType.EmailAddress)]
        string Email { get; set; }

        [DisplayName("User Name")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$",ErrorMessage =" Please Enter a Valid Username")]
        [Required]
        [MaxLength(50, ErrorMessage = "Please enter a username between 7 to 50 character ")]
        string Username { get; set; }

        [DisplayName("Password")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$",ErrorMessage = " Please Enter a Valid Username")]
        [Required]
        [DataType(DataType.Password)]
        string Password { get; set; }
    }
    [MetadataType(typeof(IUserMetadata))]
    public partial class User { }
}
