using IoTDevicesProject.Business_logic;
using IoTDevicesProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTDevicesProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZoneController : Controller
    {
        private ZoneFunctions zf;
        public ZoneController(ZoneFunctions zoneFunc)
        {
            zf = zoneFunc;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Zone))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Index()
        {
            return Ok(zf.getAllZones());
        }
    }
}
