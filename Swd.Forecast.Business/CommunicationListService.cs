using Swd.Forecast.Model;
using Swd.Forecast.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Business
{
    public class CommunicationListService
    {

        private ICommunicationListRepository _repository; 


        public CommunicationListService() {
        
            _repository = new CommunicationListRepository();
        }


        public void Add(CommunicationList item)
        {
            _repository.Add(item);
        }

        public void Update(CommunicationList item)
        {
            _repository.Update(item, item.Id);
        }

        public void Delete(CommunicationList item)
        {
            _repository.Delete(item.Id);
        }

        public CommunicationList ReadByKey(CommunicationList item)
        {
            return _repository.ReadByKey(item.Id);
        }

        public CommunicationList ReadById(int id)
        {
            return _repository.ReadByKey(id);
        }


        public IQueryable<CommunicationList> ReadAll()
        {
            return _repository.ReadAll();
        }


        public IQueryable<CommunicationList> ReadAllByNotSent()
        {
            return _repository.ReadAll().Where(c=>c.IsSent == false);
        }

    }
}
