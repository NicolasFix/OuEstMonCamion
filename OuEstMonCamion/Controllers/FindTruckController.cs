using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OuEstMonCamion.Models;
using OuEstMonCamion.Service;
using OuEstMonCamion.ViewModels;

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
            TruckFindViewModel tm = new TruckFindViewModel();
            return View(tm);
        }

        [HttpPost]
        public ActionResult Details(TruckFindViewModel trucksvm)
        {
            try
            {

                List<TruckModel> trucks = _truckService.GetTrucks();
                var trucksToDisplay = trucks.Where(x => x.Couleur.ToLower() == trucksvm.couleur.ToLower()).ToList();
                trucksvm.Trucks = trucksToDisplay;
                foreach (var truck in trucksvm.Trucks)
                {
                    truck.DerniereGeo = truck.GpsCoords.OrderByDescending(x => x.date).FirstOrDefault();
                }
                return View(trucksvm);
            }
            catch (Exception)
            {
                return View(trucksvm);
            }
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