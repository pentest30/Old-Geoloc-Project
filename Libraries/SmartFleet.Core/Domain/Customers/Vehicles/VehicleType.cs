using System;
using System.ComponentModel.DataAnnotations;

namespace SmartFleet.Core.Domain.Customers.Vehicles
{
    public enum VehicleType:Int32
    {
        [Display(Name = "Véhicule léger")]
        Car,
        [Display(Name = "Tracteur")]
        Track,
        [Display(Name = "Bus")]
        Bus

    }
}