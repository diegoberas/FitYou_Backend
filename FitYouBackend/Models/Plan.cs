using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TypeOfPlan { get; set; }
        public DateTime CreateDate { get; set; }
        public string ActiveTime { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

        public Administrator Administrator { get; set; }
        public int AdministratorId { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }


    }
}