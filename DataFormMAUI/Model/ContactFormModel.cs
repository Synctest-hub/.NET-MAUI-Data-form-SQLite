using SQLite;
using Syncfusion.Maui.DataForm;
using System.ComponentModel.DataAnnotations;

namespace DataFormMAUI
{
    public class ContactFormModel
    {
        [PrimaryKey, AutoIncrement]
        [Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [DataFormDisplayOptions(ColumnSpan = 2, ShowLabel = false)]
        public string ProfileImage { get; set; }

        [Display(ShortName = "First name")]
        [Required(ErrorMessage = "Name should not be empty")]
        public string Name { get; set; }

        [Display(ShortName = "Last name")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Invalid phone number")]
        public string Mobile { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Landline { get; set; }

        [DataFormDisplayOptions(ColumnSpan = 2)]
        public string Address { get; set; }

        [DataFormDisplayOptions(ColumnSpan = 2)]
        public string City { get; set; }

        public string State { get; set; }

        [Display(ShortName = "Zip code")]
        public string ZipCode { get; set; }

        public string Email { get; set; }

    }
}
