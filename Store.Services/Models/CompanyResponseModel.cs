using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Services.Models
{
    public class CompanyResponseModel
    {

        public int Id { get; set; }
        public string PersianName { get; set; }
        public string EnglishName { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }

    }
}