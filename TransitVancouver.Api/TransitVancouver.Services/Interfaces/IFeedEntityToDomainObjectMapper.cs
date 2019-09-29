using System;
using System.Collections.Generic;
using System.Text;
using TransitRealtime;
using VehiclePosition = TransitVancouver.Services.Models.VehiclePosition;
namespace TransitVancouver.Services.Interfaces
{
    public interface IFeedEntityToDomainObjectMapper
    {
        VehiclePosition MapEntityToVehiclePosition(FeedEntity feedEntity); 
    }
}
