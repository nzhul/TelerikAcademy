namespace MusicApp.Web.Controllers
{
    using MusicApp.Data;
    using MusicApp.Models;
    using MusicApp.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class ArtistController : ApiController
    {
        private IMusicAppData data;

        public ArtistController()
            : this(new MusicAppData())
        {

        }
        public ArtistController(IMusicAppData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.data.Artists.All().Select(b => new ArtistModel
            {
                Name = b.Name,
                DateOfBirth = b.DateOfBirth,
                Country = b.Country
            });
            return Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var artist = this.data.Artists.All().FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return BadRequest("Artist does not exists - invalid ID");
            }
            return Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Create(ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var newArtist = new Artist
                {
                    Name = artist.Name,
                    DateOfBirth = artist.DateOfBirth,
                    Country = artist.Country
                };

                this.data.Artists.Add(newArtist);
                this.data.Artists.SaveChanges();

                artist.Id = newArtist.Id;
                return Ok(newArtist);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Artist artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingArtist = this.data.Artists.All().FirstOrDefault(a => a.Id == id);
            if (existingArtist == null)
            {
                return BadRequest("Such aircraft does not exists!");
            }

            existingArtist.Name = artist.Name;
            existingArtist.DateOfBirth = artist.DateOfBirth;
            existingArtist.Country = artist.Country;
            this.data.Artists.SaveChanges();

            return Ok(existingArtist);
        }
 

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.data.Artists.All().FirstOrDefault(a => a.Id == id);
            if (existingArtist == null)
            {
                return BadRequest("Such song does not exists!");
            }

            this.data.Artists.Delete(existingArtist);
            this.data.Artists.SaveChanges();

            return Ok("Song successfuly deleted!");
        }


        // AddAlbum to the Artist

        [HttpPost]
        public IHttpActionResult AddAlbum(int artistId, int albumId)
        {
            var theArtist = this.data.Artists.All().FirstOrDefault(a => a.Id == artistId);
            if (theArtist == null)
            {
                BadRequest("Such album does not exists!");
            }

            var theAlbum = this.data.Albums.All().FirstOrDefault(b => b.Id == albumId);
            if (theAlbum == null)
            {
                return BadRequest("Such song does not exists! - invalid ID");
            }

            theArtist.Albums.Add(theAlbum);
            theAlbum.ArtistId = artistId;
            this.data.Albums.SaveChanges();
            this.data.Artists.SaveChanges();
            return Ok("Success");
        }
    }
}
