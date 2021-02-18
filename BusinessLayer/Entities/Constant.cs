using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_Services.BusinessLayer.Entities
{
    public class Constant
    {
        // make on list
        public static readonly List<string> Parameters = new List<string>() { "firstname", "lastname", "createdDate"};
        public static readonly List<string> Directions = new List<string>() { "asc", "desc"};
    }
}
