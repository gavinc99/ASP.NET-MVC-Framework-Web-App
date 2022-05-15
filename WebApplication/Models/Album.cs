using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Album
    {
        private ICollection<Song> _songs;
        public Album()
        {
            _songs = new List<Song>();
        }
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public string Song { get; set; }
        public DateTime Released { get; set; }


        public virtual ICollection<Song> Songs
        {
            get { return _songs; }
            set { _songs = value; }
        }
    }
}