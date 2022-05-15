using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication.Models;
using System.Web;
using System.Threading.Tasks;

namespace WebApplication.API
{
    public class SongsController : ApiController
    {
        private SongsModelContext db = new SongsModelContext();

    public IQueryable<SongDTO> GetSongs()
        {
            var songs = from b in db.Songs
                        select new SongDTO()
                        {
                            SongId = b.SongId,
                            Name = b.Name,
                            Album=b.Album,

                            Artists=b.Artists.Select(a=> new ArtistDTO(){
                               ArtistId=a.ArtistId,
                               Name=a.Name

                            }

                            ).ToList()
                            
                            
                        };
            return songs;
        }

        [ResponseType(typeof(SongDTO))]
        public async Task<IHttpActionResult> GetSong(int SongId)
        {
            Song b = await db.Songs.FindAsync(SongId);
            if (b == null)
            {
                return NotFound();
            }
            SongDTO song = new SongDTO
            {
                SongId = b.SongId,
                Name = b.Name,
                Album = b.Album,

                Artists = b.Artists.Select(a => new ArtistDTO()
                {
                    ArtistId = a.ArtistId,
                    Name = a.Name

                }

                            ).ToList()
            };
            return Ok(song);
        }

        // PUT: api/Songs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != song.SongId)
            {
                return BadRequest();
            }

            db.Entry(song).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Songs
        [ResponseType(typeof(Song))]
        public IHttpActionResult PostSong(Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Songs.Add(song);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = song.SongId }, song);
        }

        // DELETE: api/Songs/5
        [ResponseType(typeof(Song))]
        public IHttpActionResult DeleteSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            db.Songs.Remove(song);
            db.SaveChanges();

            return Ok(song);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SongExists(int id)
        {
            return db.Songs.Count(e => e.SongId == id) > 0;
        }
    }
}