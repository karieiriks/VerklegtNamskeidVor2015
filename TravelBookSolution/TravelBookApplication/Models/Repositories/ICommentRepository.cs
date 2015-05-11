using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> Comments { get; }
        Comment Save(Comment comment);
        void Delete(Comment comment);
    }
}
