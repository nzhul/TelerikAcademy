namespace MusicApp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using MusicApp.Data;
    using MusicApp.Web.Models;
    using MusicApp.Models;
    public class SongsController : ApiController
    {
        private IMusicAppData data;

        public SongsController()
            : this(new MusicAppData())
        {

        }
        public SongsController(IMusicAppData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var songs = this.data.Songs.All().Select(b => new SongModel
            {
                Id = b.Id,
                Title = b.Title,
                Genre = b.Genre,
                Length = b.Length,
                Producer = b.Producer,
                Year = b.Year
            });
            return Ok(songs);
        }

        [HttpPut]
        public IHttpActionResult Create(SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var newSong = new Song
                {
                    Title = song.Title,
                    Year = song.Year,
                    Genre = song.Genre,
                    Length = song.Length,
                    Producer = song.Producer
                };

                this.data.Songs.Add(newSong);
                this.data.Songs.SaveChanges();

                song.Id = newSong.Id;
                return Ok(newSong);
            }
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var song = this.data.Songs.All().FirstOrDefault(a => a.Id == id);
            if (song == null)
            {
                return BadRequest("Song does not exists - invalid ID");
            }
            return Ok(song);
        }


        [HttpPut]
        public IHttpActionResult Update(int id, SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSong = this.data.Songs.All().FirstOrDefault(a => a.Id == id);
            if (existingSong == null)
            {
                return BadRequest("Such aircraft does not exists!");
            }

            existingSong.Title = song.Title;
            existingSong.Year = song.Year;
            existingSong.Genre = song.Genre;
            existingSong.Length = song.Length;
            existingSong.Producer = song.Producer;
            this.data.Songs.SaveChanges();

            return Ok(existingSong);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingSong = this.data.Songs.All().FirstOrDefault(a => a.Id == id);
            if (existingSong == null)
            {
                return BadRequest("Such song does not exists!");
            }

            this.data.Songs.Delete(existingSong);
            this.data.Songs.SaveChanges();

            return Ok("Song successfuly deleted!");
        }
    }
}
