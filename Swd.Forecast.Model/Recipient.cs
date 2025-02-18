using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string Salutation
        {
            get { return _salutation; }
            set
            {
                SetProperty(ref _salutation, value);
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                SetProperty(ref _lastname, value);
            }
        }

        public string Firstname
        {
            get { return _firstname; }
            set {
                SetProperty(ref _firstname, value); 
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

        public string GeoInformation
        {
            get { return _geoInformation; }
            set
            {
                SetProperty(ref _geoInformation, value);
            }
        }

        public string CommunicationData
        {
            get { return _communicationData; }
            set
            {
                SetProperty(ref _communicationData, value);
            }
        }
    }
}
