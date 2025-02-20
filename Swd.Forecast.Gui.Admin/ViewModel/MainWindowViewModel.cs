using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Swd.Forecast.Business;
using Swd.Forecast.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Input;

namespace Swd.Forecast.Gui.Admin.ViewModel
{
    public class MainWindowViewModel: ObservableObject
    {
        
        //Interne Felder
        private string _searchValue;
        private string _searchValueRecipient;
        private int _recordCount;
        private ObservableCollection<MeasuredData> _weatherDataList;

        private ObservableCollection<Recipient> _recipientList;
        private Recipient _selectedRecipient;


        //Commands
        public ICommand SearchCommand
        {
            get;
        }
        public ICommand AddCommand
        {
            get;
        }
        public ICommand SaveCommand
        {
            get;
        }
        public ICommand DeleteCommand
        {
            get;
        }
        public ICommand ExitCommand
        {
            get;
        }

        //Properties für Binding
        public string SearchValue
        {
            get { return _searchValue; }
            set { 
                SetProperty(ref _searchValue, value);
                //_searchValue = value; 
            }
        }
        public string SearchValueRecipient
        {
            get { return _searchValueRecipient; }
            set
            {
                SetProperty(ref _searchValueRecipient, value);
                
                RecipientService _recipientService = new RecipientService();
                RecipientList = new ObservableCollection<Recipient>(_recipientService
                    .ReadAll()
                    .Where(r => r.Firstname.Contains(_searchValueRecipient))
                    .OrderBy(r => r.Lastname)
                    .OrderBy(r => r.Firstname)
                    .Take(100)
                    .ToList()
                    );

            }
        }
        public int RecordCount
        {
            get { return _recordCount; }
            set { 
                SetProperty(ref _recordCount, value);
                }
        }

        public ObservableCollection<MeasuredData> WeatherDataList
        {
            get { return _weatherDataList; }
            set
            {
                SetProperty(ref _weatherDataList, value);
            }
        }


        public Recipient SelectedRecipient
        {
            get { return _selectedRecipient; }
            set
            {
                SetProperty(ref _selectedRecipient, value);
            }
        }
        public ObservableCollection<Recipient> RecipientList
        {
            get { return _recipientList; }
            set
            {
                SetProperty(ref _recipientList, value);
            }
        }



        public MainWindowViewModel()
        {
            MeasuredDataService service = new MeasuredDataService();
            RecipientService _recipientService = new RecipientService();

            SearchCommand = new RelayCommand(SearchCommandExecute);
            AddCommand = new RelayCommand(AddCommandExecute);
            SaveCommand = new RelayCommand(SaveCommandExecute);
            DeleteCommand = new RelayCommand(DeleteCommandExecute);
            ExitCommand = new RelayCommand(ExitCommandExecute);

            WeatherDataList = new ObservableCollection<MeasuredData>(service
                                .ReadAll()
                                .Where(w => w.TypeOfMeasuredDataId == "Temperature")
                                .OrderByDescending(w => w.MeasuredDateTime)
                                .Take(100)
                                .ToList());

            RecipientList = new ObservableCollection<Recipient>(_recipientService
                                .ReadAll()
                                .OrderBy(r => r.Lastname)
                                .OrderBy(r => r.Firstname)
                                .Take(100)
                                .ToList()
                                );


            this.RecordCount = WeatherDataList.Count;



        }






        public void SearchCommandExecute()
        {
            MeasuredDataService service = new MeasuredDataService();

            string searchValue = SearchValue;

            //_weatherDataList.Clear();
            WeatherDataList = new ObservableCollection<MeasuredData>(service
                           .ReadAll()
                           .Where(w => w.TypeOfMeasuredDataId == "Temperature" && w.MeasuredValue.Contains(searchValue))
                           .OrderByDescending(w => w.MeasuredDateTime)
                           .Take(100)
                           .ToList());

            this.RecordCount = WeatherDataList.Count;
        }


        public void AddCommandExecute()
        {
            Recipient r0 = new Recipient();
            r0.Salutation = "Frau";
            r0.IsActive = true;
            SelectedRecipient = r0;
        }
        public void SaveCommandExecute()
        {
            RecipientService _recipientService = new RecipientService();
            Recipient changedRecipient = SelectedRecipient;

            //Wenn die Recipient-Id einen Wert <>  hat, dann existiert der Datensatz bereits in der DB
            if(changedRecipient.Id != 0)
            {
                _recipientService.Update(changedRecipient);
            }
            //ansonsten ist es ein neuer Datensatz
            else
            {
                _recipientService.Add(changedRecipient);
                RecipientList.Add(changedRecipient);
            }
            
        }

        public void DeleteCommandExecute()
        {
            RecipientService _recipientService = new RecipientService();
            _recipientService.Delete(SelectedRecipient);
            RecipientList.Remove(SelectedRecipient);
        }


        public void ExitCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("Anwendung schliessen?", "Beenden",
                                                       MessageBoxButton.YesNo,
                                                       MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
