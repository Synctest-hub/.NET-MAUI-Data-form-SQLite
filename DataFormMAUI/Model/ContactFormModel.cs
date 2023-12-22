using SQLite;
using Syncfusion.Maui.DataForm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataFormMAUI
{
    public class ContactFormModel : INotifyPropertyChanged
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

        private string mobile;

        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Invalid phone number")]
        public string Mobile
        {
            get { return mobile; }
            set
            {
                mobile = value;
                if (!string.IsNullOrEmpty(mobile))
                {
                    char[] specialCharacters = { '(', ')', '-', ' ' };
                    if (mobile[0] == specialCharacters[0])
                    {
                        mobile = new string(value.Where(c => Char.IsLetterOrDigit(c)).ToArray());
                    }
                    RaisePropertyChanged(nameof(Mobile));
                    if (mobile.Length == 10)
                        this.MaskedMobileText = string.Format("({0}) {1}-{2}", mobile.Substring(0, 3), mobile.Substring(3, 3), mobile.Substring(6));
                }
            }
        }

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

        private string maskedMobileText;

        [Display(AutoGenerateField = false)]
        public string MaskedMobileText
        {
            get { return maskedMobileText; }
            set
            {
                this.maskedMobileText = value;
                RaisePropertyChanged(nameof(MaskedMobileText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
