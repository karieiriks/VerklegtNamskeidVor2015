using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.Repositories
{
    public interface IGroupRepository
    {
        IQueryable<UserContent> UserContents { get; }
        Group Save(Group group);
        void Delete(Group group);
    }
}