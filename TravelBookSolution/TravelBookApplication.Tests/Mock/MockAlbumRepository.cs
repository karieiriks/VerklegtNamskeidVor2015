using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models.Repositories;

namespace TravelBookApplication.Tests.Mock
{
    public class MockAlbumRepository : IAlbumRepository
    {
        private List<Album> al = new List<Album>();

        public List<Album> Albums
        {
            get { return al;}
            set { }
        }

        public Album Save(Album a)
        {
            Albums.Add(a);
            return a;
        }

        public void Delete(Album a)
        {
            var s = (from x in Albums
                where a.ID == x.ID
                select a).SingleOrDefault();
            Albums.Remove(s);

        }
        
        public Album GetAlbumById(int id)
        {
            return (from x in al
                    where x.ID == id
                    select x).SingleOrDefault();
        }

        public Album GetAlbumById(int id, IAlbumRepository db)
        {
            return (from x in db.Albums
                    where x.ID == id
                    select x).SingleOrDefault();

        }

        public Album GetAlbumByName(string name, IAlbumRepository db)
        {
            return (from x in db.Albums
                    where x.Name == name
                    select x).SingleOrDefault();

        }

        public Album AddAlbum(Album album, IAlbumRepository db)
        {
            db.Save(album);
            return album;
        }
    }

}
