using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;
using EldenRing.Models.LocationModels;
using EldenRing.WebMVC.Models;

namespace EldenRing.Services
{
    public class LocationService
    {
        public bool CreateLocation(LocationCreate model)
        {
            var entity = new Location
            {
                Name = model.Name,
                Region = model.Region
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LocationListItem> GetLocations()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Locations.Select(l => new LocationListItem
                {
                    Name = l.Name,
                    Region = l.Region
                });
                return query.ToArray();
            }
        }
        public LocationDetail GetLocationById(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(l => l.LocationId == locationId);
                return
                    new LocationDetail
                    {
                        Name = entity.Name,
                        Region = entity.Region
                    };
            }
        }
        public bool UpdateLocation(LocationEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(l => l.LocationId == model.LocationId);
                entity.Name = model.Name;
                entity.Region = model.Region;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLocation(int locationId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(l => l.LocationId == locationId);
                ctx.Locations.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
