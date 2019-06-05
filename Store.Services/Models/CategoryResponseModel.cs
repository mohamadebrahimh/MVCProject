using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Services.Models
{
    public class CategoryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}