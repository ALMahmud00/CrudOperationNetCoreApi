using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudOperationApi.IServices;
using CrudOperationApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftdrinksController : ControllerBase
    {
       
        private readonly ISoftdrinksService softdrinksService;
        public SoftdrinksController(ISoftdrinksService softdrinks)
        {
            softdrinksService = softdrinks;
        }

        [HttpGet]
        public string Flag()
        {
            return "Build Successful!";
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Softdrinks/GetSoftdrinks")]
        public IEnumerable<Softdrinks> GetSoftdrinks()
        {
            return softdrinksService.GetSoftdrinks();
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Softdrinks/GetSoftdrinksById")]
        public Softdrinks GetSoftdrinksById(int id)
        {
            return softdrinksService.GetSoftdrinksById(id);
        }


        [HttpPost]
        [Route("[action]")]
        [Route("api/Softdrinks/AddSoftdrinks")]
        public Softdrinks AddSoftdrinks(Softdrinks softdrinks)
        {
            return softdrinksService.AddSoftdrinks(softdrinks);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("api/Softdrinks/UpdateSoftdrinks")]
        public Softdrinks UpdateSoftdrinks(Softdrinks softdrinks)
        {
            return softdrinksService.UpdateSoftdrinks(softdrinks);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Softdrinks/DeleteSoftdrinks")]
        public Softdrinks DeleteSoftdrinks(int id)
        {
            return softdrinksService.DeleteSoftdrinks(id);
        }

    }
}
