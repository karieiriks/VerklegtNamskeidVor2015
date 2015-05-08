using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookApplication.Models;

namespace TravelBookApplication.Services
{
    public class BaseService
    {
        protected static ApplicationDbContext db = new ApplicationDbContext();
    }
}