using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emlak_Sitesi
{
    public class Form
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        [Display(Name = "Ad/Soyad")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "AdSoyad en fazla 50 karakter olabilir")]
        public string AdSoyad { get; set; } = "";

        [Required(ErrorMessage = "Lütfen Telefonunuzu Giriniz")]
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; } = "";

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";
        [Required]
        [Display(Name = "Konu")]
        [DataType(DataType.Text)]
        public string Konu { get; set; } = "";
        [Required]
        [Display(Name = "Mesaj")]
        [DataType(DataType.Text)]
        public string Mesaj { get; set; } = "";
    }
}