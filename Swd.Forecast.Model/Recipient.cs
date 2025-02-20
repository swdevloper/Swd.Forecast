using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class Recipient: ModelBase
    {

        private int _id;
        private string _salutation;
        private string _firstname;
        private string _lastname;
        private string _notice;
        private bool _isActive;
        private string _geoInformation;
        private string _communicationData;
        

        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
            }
        }


        [MaxLength(50, ErrorMessage = "Es sind maximal 50 Zeichen erlaubt")]
        public string Salutation
        {
            get { return _salutation; }
            set
            {
                SetProperty(ref _salutation, value, true);
            }
        }

        //[Required(AllowEmptyStrings =false, ErrorMessage ="Nachname ist ein Pflichtfeld")]
        //[MaxLength(50, ErrorMessage ="Es sind maximal 50 Zeichen erlaubt")]
        [CustomValidation(typeof(Recipient),nameof(ValidateLastname))]
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                SetProperty(ref _lastname, value, true);
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vorname ist ein Pflichtfeld")]
        [MaxLength(50, ErrorMessage = "Es sind maximal 50 Zeichen erlaubt")]
        public string Firstname
        {
            get { return _firstname; }
            set {
                SetProperty(ref _firstname, value, true); 
                }
        }

        public string Notice
        {
            get { return _notice; }
            set
            {
                SetProperty(ref _notice, value);
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
            }
        }

        [MaxLength(1000, ErrorMessage = "Es sind maximal 1000 Zeichen erlaubt")]
        public string GeoInformation
        {
            get { return _geoInformation; }
            set
            {
                SetProperty(ref _geoInformation, value, true);
            }
        }

        [MaxLength(1000, ErrorMessage = "Es sind maximal 1000 Zeichen erlaubt")]
        public string CommunicationData
        {
            get { return _communicationData; }
            set
            {
                SetProperty(ref _communicationData, value, true);
            }
        }


        public static ValidationResult ValidateLastname(string lastname, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                return new ValidationResult("Nachname darf nicht leer sein");
            }
            if (lastname.Length < 3)
            {
                return new ValidationResult("Name muss mindestens 3 Zeichen lang sein");
            }
            return ValidationResult.Success;
        }
    }
}
