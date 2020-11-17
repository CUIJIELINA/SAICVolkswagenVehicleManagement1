using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAICVolkswagenVehicleManagement_Model
{
    public class Role_Permission
    {
        [Key]
        public Guid ConnectionID { get; set; }
        public Guid RoleID { get; set; }
        public Guid PermissionID { get; set; }
        public int Permission { get; set; }
    }
}
