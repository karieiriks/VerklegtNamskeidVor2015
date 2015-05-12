using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.Repositories
{
    public interface IGroupRepository
    {
        List<Group> Groups { get; }
        Group Save(Group group);
        void Delete(Group group);
    }
}