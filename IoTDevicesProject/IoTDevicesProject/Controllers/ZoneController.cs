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

        [HttpGet]
        [Route("zoneWithId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Zone))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getZoneWithId(Guid id)
        {
            if(id != null)
            {
                return Ok(zf.getZoneWithId(id));
            }
            return Ok("Id not found");
        }
        [HttpDelete]
        [Route("deleteZone")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Zone))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult deleteZone(Zone a)
        {
            if (a != null)
            {
                zf.deleteZone(a);
                return Ok("Zone sucessfully deleted");
            }
            return Ok("zone not found");
        }

        [HttpPatch]
        [Route("updateZone")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Zone))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult updatezone(Zone a)
        {
            if (a != null)
            {
                zf.updateZone(a);
                return Ok("Zone sucessfully updated");
            }
            return Ok("zone not found");
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Zone))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult addZone(Zone a)
        {
            if (a != null)
            {
                zf.createZone(a);
                return Ok("Zone sucessfully added");
            }
            return Ok("Error adding new zone");
        }

        [HttpGet]
        [Route("zoneDevices")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Zone))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getZoneDevices(Guid a)
        {
            if (a != null)
            {
                return Ok(zf.getZoneDevices(a));
            }
            return Ok("Zone id not found");
        }

    }
}
