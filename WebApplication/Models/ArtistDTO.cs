using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ArtistDTO
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public List<SongDTO> Songs { get; set; }
    }
}