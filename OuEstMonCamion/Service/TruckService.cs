using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OuEstMonCamion.Models;

namespace OuEstMonCamion.Service
{
    public class TruckService : ITruckService
    {
        public List<TruckModel> GetTrucks()
        {
            var truckData = System.IO.File.ReadAllText("Data/data.json");
            var ltrucks = JsonConvert.DeserializeObject<List<TruckModel>>(truckData);

            

            return ltrucks;
        }
    }
}
