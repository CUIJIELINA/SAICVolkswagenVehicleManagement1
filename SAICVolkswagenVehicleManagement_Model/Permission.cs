using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAICVolkswagenVehicleManagement_Model
{
    public class Permission
    {
        [Key]
        public Guid PermissionID { get; set; }
        public string PermissionName { get; set; }
        public Guid UpID { get; set; }
        public string PermissionUrl { get; set; }
    }
}
