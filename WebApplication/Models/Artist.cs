using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Artist
    {
        private ICollection<Song> _songs;
        public Artist()
        {
            _songs = new List<Song>();
        }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Song { get; set; }
        public string Album { get; set; }
        

    public virtual ICollection<Song> Songs
        {
            get { return _songs; }
            set { _songs = value; }
        }
    }
}