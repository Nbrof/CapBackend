using backend.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace backend.Controllers
{
    [Route("data")] // designate controller for "/data" endpoints
    public class SatDataController
    {

        // declare property to hold Database Context
        private readonly SatDataContext Data;

        // define constructor to receive databse context via DI
        public SatDataController(SatDataContext data){
            Data = data;
        }

        [HttpGet] // get request to "/data"
        public IEnumerable<SatData> index(){
            // return all the data
            return Data.TodoItems.ToList();
        }

        [HttpPost] // post request to "/data
        public IEnumerable<SatData> Post([FromBody]SatData data){
            // add information
            Data.TodoItems.Add(data);
            // save changes
            Data.SaveChanges();
            // return all the data
            return Data.TodoItems.ToList();
        }

        [HttpGet("{id}")] // get requestion to "data/{id}"
        public SatData show(long id){
            // return the specified data matched based on ID
            return Data.TodoItems.FirstOrDefault(x => x.Id == id);
        }

        [HttpPut("{id}")] // put request to "data/{id}
        public IEnumerable<SatData> update([FromBody]SatData data, long id){
            // retrieve data to be updated
            SatData oldData = Data.TodoItems.FirstOrDefault(x => x.Id == id);
            //update their properties, can also be done with Data.TodoItems.Update
            oldData.Mission = data.Mission;
            oldData.Payload = data.Payload;
            oldData.Date = data.Date;
            oldData.Location = data.Location;
            // Save changes
            Data.SaveChanges();
            // return updated list of data
            return Data.TodoItems.ToList();
        }

        [HttpDelete("{id}")] // delete request to "data/{id}
        public IEnumerable<SatData> destroy(long id){
            //retrieve existing data
            SatData oldData = Data.TodoItems.FirstOrDefault(x => x.Id == id);
            //remove them
            Data.TodoItems.Remove(oldData);
            // saves changes
            Data.SaveChanges();
            // return updated list of data
            return Data.TodoItems.ToList();
        }

    }
}