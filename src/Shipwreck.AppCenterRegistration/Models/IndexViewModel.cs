using System.ComponentModel.DataAnnotations;

namespace Shipwreck.AppCenterRegistration.Models
{
    public class IndexViewModel : ViewModel
    {
        public bool? Result { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }
    }
}