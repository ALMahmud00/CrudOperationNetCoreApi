using System;
using System.Collections.Generic;

namespace CrudOperationApi.Models
{
    public partial class Softdrinks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Stock { get; set; }
    }
}
