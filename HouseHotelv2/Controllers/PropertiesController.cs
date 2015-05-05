using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseHotelv2.Infrastructure;



namespace HouseHotelv2.Controllers
{
    public class PropertiesController : ApiController
    {
        private happyhousesv4Entities db = new happyhousesv4Entities();
        
        // GET ...api/properties
        public IEnumerable<Property> GetAllProperties()
        {
            return db.Properties;
        }

       
        [HttpGet]
        // ...GET api/properties/P0005
        public Property GetPropertyById(string id)
        {
            return db.Properties.First(p => p.PropertyID == id);

        }
        // .../api/properties?country=italy
        public IHttpActionResult GetPropertiesByCountry(String country)
        {
            // LINQ query, find matching entries for name
            var entries = db.Properties.Where(p => p.Country.ToUpper() == country.ToUpper());
            if (entries == null)
            {
                return NotFound();
            }
            return Ok(entries);
        }
       // .../api/properties?description=caravan
        public IHttpActionResult GetPropertiesByType(String description)
        {
            // LINQ query, find matching entries for caravan
            var entries = db.Properties.Where(p => p.Unit_description.ToUpper() == description.ToUpper());
            if (entries == null)
            {
                return NotFound();
            }
            return Ok(entries);
        }
        // .../api/properties?bedrooms=3
        public IHttpActionResult GetPropertiesByNoOfBedrooms(String bedrooms)
        {
            // LINQ query, find matching entries for caravan
            var entries = db.Properties.Where(p => p.Number_of_Bedrooms.ToUpper() == bedrooms.ToUpper());
            if (entries == null)
            {
                return NotFound();
            }
            return Ok(entries);
        }
        // .../api/properties?availability=1
        public IHttpActionResult GetAvailability(String availability)
        {
            // LINQ query, find matching entries for caravan
            var entries = db.Properties.Where(p => p.Availability.ToUpper() == availability.ToUpper());
            if (entries == null)
            {
                return NotFound();
            }
            return Ok(entries);
        }
    

      
    }
}