using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.ComponentModel.DataAnnotations;

namespace SouqDotNet.ViewModels
{
    public class OrderViewModel
    {
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public char Status { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
    }
}