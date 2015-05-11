using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.Repositories
{
    public interface IAlbumRepository
    {
        List<Album> Albums { get; }
        Album Save(Album album);
        void Delete(Album album);
        Album GetAlbumById(int id);
    }
}
