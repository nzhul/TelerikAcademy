using MusicApp.Data;
using MusicApp.Models;
using MusicApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicApp.Web.Controllers
{
    public class AlbumsController : ApiController
    {
        private IMusicAppData data;

        public AlbumsController()
            : this(new MusicAppData())
        {

        }
        public AlbumsController(IMusicAppData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.data.Albums.All().Select(b => new AlbumModel
            {
                Title = b.Title,
                Year = b.Year,
                Producer = b.Producer,
            });
            return Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var album = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return BadRequest("Album does not exists - invalid ID");
            }
            return Ok(album);
        }

        [HttpPut]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var newAlbum = new Album
                {
                    Title = album.Title,
                    Year = album.Year,
                    Producer = album.Producer,
                };

                this.data.Albums.Add(newAlbum);
                this.data.Albums.SaveChanges();

                album.Id = newAlbum.Id;
                return Ok(newAlbum);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (existingAlbum == null)
            {
                return BadRequest("Such aircraft does not exists!");
            }

            existingAlbum.Title = album.Title;
            existingAlbum.Year = album.Year;
            existingAlbum.Producer = album.Producer;
            this.data.Songs.SaveChanges();

            return Ok(existingAlbum);
        }
 

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (existingAlbum == null)
            {
                return BadRequest("Such song does not exists!");
            }

            this.data.Albums.Delete(existingAlbum);
            this.data.Albums.SaveChanges();

            return Ok("Song successfuly deleted!");
        }


        // AddSong to the album
        // TODO: Not WORKING!
        // FIND WHY!

        [HttpPost]
        public IHttpActionResult AddSong(int albumId, int songId)
        {
            var theAlbum = this.data.Albums.All().FirstOrDefault(a => a.Id == albumId);
            if (theAlbum == null)
            {
                BadRequest("Such album does not exists!");
            }

            var theSong = this.data.Songs.All().FirstOrDefault(b => b.Id == songId);
            if (theSong == null)
            {
                return BadRequest("Such song does not exists! - invalid ID");
            }

            theAlbum.Songs.Add(theSong);
            theSong.AlbumId = albumId;
            this.data.Songs.SaveChanges();
            this.data.Albums.SaveChanges();
            return Ok("Success");
        }


    }
}
