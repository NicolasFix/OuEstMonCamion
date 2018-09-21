using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OuEstMonCamion.Models
{
    public class TruckModel
    {
        [Display(Name = "Identifiant Camion")]
        [DataType(DataType.Text)]
        public string RequestId { get; set; }

        public string Id { get; set; }

        [Display(Name = "Emplacement")]
        public string Emplacement { get; set; }
        

        public GpsCoordModel DerniereGeo { get; set; }

        [Display(Name = "Couleur")]
        public string Couleur { get; set; }
        

        public bool detail { get; set; }

        #region moduleGPS
        [Display(Name = "Niveau de batterie")]
        public string NiveaudeBatterie { get; set; }
        public string FirmwareVersion { get; set; }
        public List<GpsCoordModel> GpsCoords { get; set; }
        #endregion

        
    }
}
