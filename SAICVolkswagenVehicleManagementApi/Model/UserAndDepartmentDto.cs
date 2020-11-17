using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAICVolkswagenVehicleManagementApi.Model
{
    public class UserAndDepartmentDto
    {
        public Guid UserID { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserPassWord { get; set; }
        public Guid Department_ID { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
