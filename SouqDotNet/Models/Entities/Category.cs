﻿using System;
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
    [MetadataType(typeof(ICategoryMetadata))]
    public partial class Category
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}