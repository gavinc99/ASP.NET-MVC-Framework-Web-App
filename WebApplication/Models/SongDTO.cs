using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SongDTO
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public string Album { get; set; }
        public List<ArtistDTO> Artists { get; set; }
    }
}