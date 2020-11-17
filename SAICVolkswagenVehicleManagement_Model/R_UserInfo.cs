using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAICVolkswagenVehicleManagement_Model
{
    public class R_UserInfo
    {
        [Key]
        public Guid UserID { get; set; }
        public string UserCode { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassWord { get; set; }
        public Guid Department_ID { get; set; }
    }
}
