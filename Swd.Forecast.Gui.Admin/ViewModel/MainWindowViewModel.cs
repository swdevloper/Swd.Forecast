using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Swd.Forecast.Business;
using Swd.Forecast.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Input;

namespace Swd.Forecast.Gui.Admin.ViewModel
{
    public class MainWindowViewModel
    {
        //Interne Felder
        private string _searchValue;
        private int _recordCount;
        private ObservableCollection<MeasuredData> _weatherDataList;


        //Commands
        public ICommand SearchCommand
        {
            get;
        }


        //Properties für Binding
        public string SearchValue
        {
            get { return _searchValue; }
            set { 
                _searchValue = value; 
            }
        }

        public int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        public ObservableCollection<MeasuredData> WeatherDataList
        {
            get { return _weatherDataList; }
        }


        public MainWindowViewModel()
        {
            MeasuredDataService service = new MeasuredDataService();

            SearchCommand = new RelayCommand(SearchCommandExecute);

            _weatherDataList = new ObservableCollection<MeasuredData>(service
                                .ReadAll()
                                .Where(w => w.TypeOfMeasuredDataId == "Temperature")
                                .OrderByDescending(w => w.MeasuredDateTime)
                                .Take(100)
                                .ToList());
            
            this.RecordCount = _weatherDataList.Count;
        }






        public void SearchCommandExecute()
        {
            MeasuredDataService service = new MeasuredDataService();

            string searchValue = SearchValue;

            //_weatherDataList.Clear();
            _weatherDataList = new ObservableCollection<MeasuredData>(service
                           .ReadAll()
                           .Where(w => w.TypeOfMeasuredDataId == "Temperature" && w.MeasuredValue.Contains(searchValue))
                           .OrderByDescending(w => w.MeasuredDateTime)
                           .Take(100)
                           .ToList());

            this.RecordCount = _weatherDataList.Count;
        }

    }
}
