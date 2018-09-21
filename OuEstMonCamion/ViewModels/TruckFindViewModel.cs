using OuEstMonCamion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OuEstMonCamion.ViewModels
{
    public class TruckFindViewModel
    {
        public List<TruckModel> Trucks {get; set;}

        [Display(Name = "Couleur")]
        public string couleur { get; set; }

    }
}
