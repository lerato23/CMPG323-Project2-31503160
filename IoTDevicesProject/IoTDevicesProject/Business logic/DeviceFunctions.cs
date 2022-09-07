using IoTDevicesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTDevicesProject.Business_logic
{
    public class DeviceFunctions
    {
        private iotdevicesdatabaseContext iotdeviceDBContext;
        public DeviceFunctions(iotdevicesdatabaseContext DBContext)
        {
            iotdeviceDBContext = DBContext;
        }

        public List<Device> getAllDevices()
        {
            List<Device> devices = new List<Device>();
            devices = iotdeviceDBContext.Devices.ToList();
            return devices;
        }

        public Device getDeviceWithId(Guid deviceId)
        {
            Device device = new Device();
            device = iotdeviceDBContext.Devices.Where(x=>x.DeviceId == deviceId).Single();
            return device;
        }

        private bool deviceChecker(Guid deviceId)
        {
            Device device = iotdeviceDBContext.Devices.Where(x => x.DeviceId == deviceId).Single();
            bool result = true;
            if (device == null)
            {
                result = false;
            }
            return result;
        }

        public void createDevice(Device device)
        {
            Device device1 = new Device();
            device.DeviceId = Guid.NewGuid();
            device.DateCreated = new DateTime();
            iotdeviceDBContext.Devices.Add(device);
            iotdeviceDBContext.SaveChanges();
        }

        public void updateDevice(Device device)
        {
            if (deviceChecker(device.DeviceId))
            {
                Device device1 = new Device();
                device1.DeviceId = device.DeviceId;
                device1.DateCreated = device.DateCreated;
                device1.IsActvie = device.IsActvie;
                device1.CategoryId = device.CategoryId;
                device1.ZoneId = device.ZoneId;
                device1.DeviceName = device.DeviceName;
                device1.Status = device.Status;
                iotdeviceDBContext.Devices.Update(device1);
                iotdeviceDBContext.SaveChanges();
            }
        }

        public void deleteDevice(Device device)
        {
            if (deviceChecker(device.DeviceId))
            {
                iotdeviceDBContext.Devices.Remove(device);
                iotdeviceDBContext.SaveChanges();
            }
        }

        
    }
}
