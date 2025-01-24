using Swd.Forecast.Model;
using Swd.Forecast.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Business
{
    public class TypeOfMeasuredDataService
    {

        private ITypeOfMeasuredDataRepository _repository; 


        public TypeOfMeasuredDataService() {
        
            _repository = new TypeOfMeasuredDataRepository();
        




        }


        public void Add(TypeOfMeasuredData item)
        {
            _repository.Add(item);
        }

        public void Update(TypeOfMeasuredData item)
        {
            _repository.Update(item, item.Id);
        }

        public void Delete(TypeOfMeasuredData item)
        {
            _repository.Delete(item.Id);
        }

        public TypeOfMeasuredData ReadByKey(TypeOfMeasuredData item)
        {
            return _repository.ReadByKey(item.Id);
        }

        public IQueryable<TypeOfMeasuredData> ReadAll()
        {
            return _repository.ReadAll();
        }

    }
}
