using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models.Repositories;

namespace TravelBookApplication.Services
{
    public class AlbumService : IAlbumRepository
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public List<Album> Albums
        {
            get { return db.Albums.ToList(); }
            set { }
        }

        public Album Save(Album album)
        {
            db.Albums.Add(album);
            db.SaveChanges();
            return album;
        }

        public void Delete(Album album)
        {
            var itemToRemove = (from x in db.Albums
                where x.ID == album.ID
                select x).SingleOrDefault();
            db.Albums.Remove(itemToRemove);
        }

        public Album GetAlbumById(int id)
        {
            return (from x in db.Albums
                where x.ID == id
                select x).SingleOrDefault();
        }
    }
}