using Swd.Forecast.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Gui.Messenger
{
    public interface IMessageService
    {
        Task ProcessMessage(Message message);

    }
}
