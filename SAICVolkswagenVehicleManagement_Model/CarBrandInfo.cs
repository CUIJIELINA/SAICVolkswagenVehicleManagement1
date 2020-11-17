using System;
using System.ComponentModel.DataAnnotations;

namespace SAICVolkswagenVehicleManagement_Model
{
    public class CarBrandInfo
    {
        [Key]
        public Guid CarBrandID { get; set; }
        public string CarBrandCode { get; set; }
        public string CarBrandName { get; set; }
        public string CarBrandDescription { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
