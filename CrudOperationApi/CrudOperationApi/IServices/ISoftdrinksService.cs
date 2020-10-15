using CrudOperationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationApi.IServices
{
    public interface ISoftdrinksService
    {

        IEnumerable<Softdrinks> GetSoftdrinks();

        Softdrinks GetSoftdrinksById(int id);

        Softdrinks AddSoftdrinks(Softdrinks softdrinks);

        Softdrinks UpdateSoftdrinks(Softdrinks softdrinks);

        Softdrinks DeleteSoftdrinks(int id);

        
    }
}
