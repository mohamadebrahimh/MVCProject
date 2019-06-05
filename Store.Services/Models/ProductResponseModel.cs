using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Services.Models
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
    }
}