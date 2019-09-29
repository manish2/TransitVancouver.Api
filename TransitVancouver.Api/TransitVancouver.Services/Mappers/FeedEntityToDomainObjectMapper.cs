using System;
using System.Collections.Generic;
using System.Text;
using TransitRealtime;
using TransitVancouver.Services.Interfaces;
using TransitVancouver.Services.Models;
using VehiclePosition = TransitVancouver.Services.Models.VehiclePosition;

namespace TransitVancouver.Services.Mappers
{
    public class FeedEntityToDomainObjectMapper : IFeedEntityToDomainObjectMapper
    {
        public VehiclePosition MapEntityToVehiclePosition(FeedEntity feedEntity)
        {
            return new VehiclePosition
            {
                VehicleName = feedEntity.Vehicle.Vehicle.Label,
                Latitude = feedEntity.Vehicle.Position.Latitude,
                Longitude = feedEntity.Vehicle.Position.Longitude
            }; 
        }
    }
}
