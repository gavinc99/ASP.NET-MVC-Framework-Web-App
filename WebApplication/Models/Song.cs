using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Song
    {
        private ICollection<Artist> _artists;
        public Song()
        {
            _artists = new List<Artist>();
        }

        public int SongId { get; set; }
        public string Name { get; set; }
        public string Album { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get { return _artists; }
            set { _artists = value; }
        }
    }
}