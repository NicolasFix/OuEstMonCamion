using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OuEstMonCamion.Models;
using OuEstMonCamion.Service;

namespace OuEstMonCamion.Controllers
{
    public class FindTruckController : Controller
    {
        private readonly ITruckService _truckService;

        public FindTruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }
        // GET: FindTruck
        public ActionResult Index()
        {
            TruckModel tm = new TruckModel();
            return View(tm);
        }
        
        public ActionResult Details()
        {
            TruckModel tm = new TruckModel();
            return View(tm);
        }

        [HttpPost]
        public ActionResult Details(TruckModel truck)
        {
            string id = truck.RequestId;
            return View(truck);
        }
        [HttpPost]
        public ActionResult Index(TruckModel truck)
        {
            try
            {

                List<TruckModel> trucks = _truckService.GetTrucks();
                string id = truck.RequestId;

                var truckToDisplay = trucks.FirstOrDefault(x => x.Id == truck.RequestId);
                truckToDisplay.DerniereGeo = truckToDisplay.GpsCoords.OrderByDescending(x => x.date).FirstOrDefault();
                truckToDisplay.detail = truck.detail;
                return View(truckToDisplay);

            }
            catch (Exception)
            {

                return View(truck);
            }
        }
    }
}