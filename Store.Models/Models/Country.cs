using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Models
{
    public class Country
    {
        public Country()
        {
            
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "نام کشور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }


        #region Relations

        public virtual List<Company> Companies { get; set; }

        #endregion

    }
}