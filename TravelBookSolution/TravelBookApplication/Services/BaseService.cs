﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Repositories;

namespace TravelBookApplication.Services
{
    public class BaseService
    {
        protected static ApplicationDbContext db = new ApplicationDbContext();
    }
}