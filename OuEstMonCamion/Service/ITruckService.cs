using OuEstMonCamion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuEstMonCamion.Service
{
    public interface ITruckService
    {
         List<TruckModel> GetTrucks();
    }
}
