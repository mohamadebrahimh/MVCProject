using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Models
{
    public class Product
    {
        public Product()
        {

        }

        [Key]
        public int Id { get; set; }


        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CategoryId { get; set; }


        [Display(Name = "برند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CompanyId { get; set; }


        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ModelName { get; set; }

        [Display(Name = "توضیحات")]
        [StringLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        #region Relations

        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }

        #endregion

    }
}