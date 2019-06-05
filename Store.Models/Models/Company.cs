using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Models
{
    public class Company
    {
        public Company()
        {

        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "نام برند به فارسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string PersianName { get; set; }

        [Display(Name = "نام برند به انگلیسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string EnglishName { get; set; }


        [Display(Name = "نام کشور")]
        public int? CountryId { get; set; }

        #region Relations

        public virtual Country Country { get; set; }
        public virtual List<Product> Products { get; set; }

        #endregion

    }
}