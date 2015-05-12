using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.Repositories
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> Users { get; }
        ApplicationUser Save(ApplicationUser applicationUser);
        void Delete(ApplicationUser applicationUser);
    }
}
