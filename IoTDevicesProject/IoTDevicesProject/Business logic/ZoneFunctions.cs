using IoTDevicesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTDevicesProject.Business_logic
{
    public class ZoneFunctions
    {
        private iotdevicesdatabaseContext iotdeviceDBContext;
        public ZoneFunctions(iotdevicesdatabaseContext DBContext)
        {
            iotdeviceDBContext = DBContext;
        }

        public List<Zone> getAllZones()
        {
            List<Zone> zones = new List<Zone>();
            zones = iotdeviceDBContext.Zones.ToList();
            return zones;
        }

        public Zone getZoneWithId(Guid zoneId)
        {
            Zone zone = new Zone();
            zone = iotdeviceDBContext.Zones.Where(x => x.ZoneId== zoneId).Single();
            return zone;
        }

        private bool zoneChecker(Guid zoneId)
        {
            Zone cat = iotdeviceDBContext.Zones.Where(x => x.ZoneId== zoneId).Single();
            bool result = true;
            if (cat == null)
            {
                result = false;
            }
            return result;
        }

        public void createZone(Zone zone)
        {
            zone.ZoneId= Guid.NewGuid();
            zone.DateCreated = new DateTime();
            iotdeviceDBContext.Zones.Add(zone);
            iotdeviceDBContext.SaveChanges();
        }

        public void updateZone(Zone zone)
        {
            if (zoneChecker(zone.ZoneId))
            {
                Zone zone1 = new Zone();
                zone1.ZoneId= zone.ZoneId;
                zone1.DateCreated = zone.DateCreated;
                zone1.ZoneName= zone.ZoneName;
                zone1.ZoneDescription= zone.ZoneDescription;
                iotdeviceDBContext.Zones.Update(zone1);
                iotdeviceDBContext.SaveChanges();
            }
        }

        public void deleteZone(Zone cat)
        {
            if (zoneChecker(cat.ZoneId))
            {
                iotdeviceDBContext.Zones.Remove(cat);
                iotdeviceDBContext.SaveChanges();
            }
        }

        public List<Device> getZoneDevices(Guid zoneId)
        {
            List<Device> allDevices = new List<Device>();
            foreach(Device a in iotdeviceDBContext.Devices.Where(x => x.ZoneId == zoneId).ToList())
            {
                allDevices.Add(a);
            }
            return allDevices;
        }
    }
}
