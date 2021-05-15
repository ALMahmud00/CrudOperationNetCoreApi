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
        [Route("GetSoftdrinks")]
        [Route("api/Softdrinks/GetSoftdrinks")]
        public IEnumerable<Softdrinks> GetSoftdrinksMETHOD()
        {
            return softdrinksService.GetSoftdrinks();
        }


        [HttpGet]
        [Route("[action]")]
        [Route("GetSoftdrinksById")]
        [Route("api/Softdrinks/GetSoftdrinksById")]
        public Softdrinks GetSoftdrinksByIdMETHOD(int id)
        {
            return softdrinksService.GetSoftdrinksById(id);
        }


        [HttpPost]
        [Route("[action]")]
        [Route("AddSoftdrinks")]
        [Route("api/Softdrinks/AddSoftdrinks")]
        public Softdrinks AddSoftdrinksMETHOD(Softdrinks softdrinks)
        {
            return softdrinksService.AddSoftdrinks(softdrinks);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("UpdateSoftdrinks")]
        [Route("api/Softdrinks/UpdateSoftdrinks")]
        public Softdrinks UpdateSoftdrinksMETHOD(Softdrinks softdrinks)
        {
            return softdrinksService.UpdateSoftdrinks(softdrinks);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("DeleteSoftdrinks")]
        [Route("api/Softdrinks/DeleteSoftdrinks")]
        public Softdrinks DeleteSoftdrinksMETHOD(int id)
        {
            return softdrinksService.DeleteSoftdrinks(id);
        }

    }
}
