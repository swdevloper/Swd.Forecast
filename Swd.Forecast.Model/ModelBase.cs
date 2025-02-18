using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class ModelBase: ObservableObject
    {
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

    }
}
