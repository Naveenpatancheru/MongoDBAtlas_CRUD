using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_MongoDB.Models
{
    public class Docket
    {
        public object _id { get; set; }
        public string docketDescription { get; set; }
        public string docketCaseId { get; set; }
        public string docketCode { get; set; }
        public string myProperty { get; set; }
    }
}