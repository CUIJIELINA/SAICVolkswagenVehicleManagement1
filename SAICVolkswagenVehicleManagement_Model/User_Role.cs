using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAICVolkswagenVehicleManagement_Model
{
    public class User_Role
    {
        [Key]
        public Guid ConnectionID { get; set; }
        public Guid UserID { get; set; }
        public Guid RoleID { get; set; }
    }
}
