using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TransitVancouver.Services.Interfaces
{
    public interface IVehiclePositionProvider
    {
        Task<string> GetCurrentVehiclePosition(string routeName); 
    }
}
