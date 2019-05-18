using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartEquipment.Controllers
{
    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        #region
        // GET: api/status
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult Get()
        {
            return Ok(new { status = "online" });
        }
        #endregion
    }
}
