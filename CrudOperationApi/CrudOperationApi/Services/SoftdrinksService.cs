using CrudOperationApi.IServices;
using CrudOperationApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationApi.Services
{
    public class SoftdrinksService : ISoftdrinksService
    {

        readonly AkijFoodDBContext dbContext;
        public SoftdrinksService(AkijFoodDBContext _db)
        {
            dbContext = _db;
        }


        public IEnumerable<Softdrinks> GetSoftdrinks()
        {
            var softdrinks = dbContext.Softdrinks.ToList();
            return softdrinks;
        }


        public Softdrinks GetSoftdrinksById(int id)
        {
            var softdrinks = dbContext.Softdrinks.FirstOrDefault(x => x.Id == id);
            return softdrinks;
        }
        

        public Softdrinks AddSoftdrinks(Softdrinks softdrinks) 
        {
            if(softdrinks != null)
            {
                dbContext.Softdrinks.Add(softdrinks);
                dbContext.SaveChanges();
                return softdrinks;
            }
            return null;
        }


        public Softdrinks UpdateSoftdrinks(Softdrinks softdrinks)
        {
            dbContext.Entry(softdrinks).State = EntityState.Modified;
            dbContext.SaveChanges();
            return softdrinks;
        }


        public Softdrinks DeleteSoftdrinks(int id)
        {
            var softdrinks = dbContext.Softdrinks.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(softdrinks).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return softdrinks;
        }

    }
}
