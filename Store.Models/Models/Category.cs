using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Models
{
    public class Category
    {
        public Category()
        {

        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        #region Relations
        public virtual List<Product> Products { get; set; }

        #endregion

    }
}