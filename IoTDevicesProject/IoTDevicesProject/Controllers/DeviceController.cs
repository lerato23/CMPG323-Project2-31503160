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
    public class DeviceController : Controller
    {
        private DeviceFunctions df;
        public DeviceController(DeviceFunctions deviceFunc)
        {
            df = deviceFunc;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Device))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Index()
        {
            return Ok(df.getAllDevices());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Device))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getDeviceWithId(Guid id)
        {
            if(id != null)
            {
                return Ok(df.getDeviceWithId(id));
            }
            return Ok("Device with ID not found");
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Device))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult create(Device a)
        {
            if(a != null)
            {
                df.createDevice(a);
                return Ok("Device added");
            }
            return NotFound("Device adding error");
        }

        [HttpPatch]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Device))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult updateDevice(Device a)
        {
            if (a != null)
            {
                df.updateDevice(a);
                return Ok("Device added");
            }
            return NotFound("Device not found error");
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Device))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult deleteDevice(Device a)
        {
            if (a != null)
            {
                df.createDevice(a);
                return Ok("Device deleted");
            }
            return NotFound("Device deleting error");
        }

    }
}
