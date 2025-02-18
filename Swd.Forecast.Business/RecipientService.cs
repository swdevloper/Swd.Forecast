using Swd.Forecast.Model;
using Swd.Forecast.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Business
{
    public class RecipientService
    {

        private IRecipientRepository _repository; 


        public RecipientService() {
        
            _repository = new RecipientRepository();
        }


        public void Add(Recipient item)
        {
            _repository.Add(item);
        }

        public void Update(Recipient item)
        {
            _repository.Update(item, item.Id);
        }

        public void Delete(Recipient item)
        {
            _repository.Delete(item.Id);
        }

        public Recipient ReadByKey(Recipient item)
        {
            return _repository.ReadByKey(item.Id);
        }

        public IQueryable<Recipient> ReadAll()
        {
            return _repository.ReadAll();
        }

    }
}
