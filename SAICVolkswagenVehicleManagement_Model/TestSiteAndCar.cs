using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAICVolkswagenVehicleManagement_Model
{
    public class TestSiteAndCar
    {
        [Key]
        public Guid TestSiteAndCarID { get; set; }
        public Guid CarID { get; set; }
        public Guid TestSiteID { get; set; }
    }
}
