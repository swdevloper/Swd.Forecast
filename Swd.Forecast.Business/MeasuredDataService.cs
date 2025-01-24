using Swd.Forecast.Model;
using Swd.Forecast.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Business
{
    public class MeasuredDataService
    {

        private IMeasuredDataRepository _repository; 


        public MeasuredDataService() {
        
            _repository = new MeasuredDataRepository();
        }


        public void Add(MeasuredData item)
        {
            _repository.Add(item);
        }

        public void Update(MeasuredData item)
        {
            _repository.Update(item, item.Id);
        }

        public void Delete(MeasuredData item)
        {
            _repository.Delete(item.Id);
        }

        public MeasuredData ReadByKey(MeasuredData item)
        {
            return _repository.ReadByKey(item.Id);
        }

        public IQueryable<MeasuredData> ReadAll()
        {
            return _repository.ReadAll();
        }

    }
}
