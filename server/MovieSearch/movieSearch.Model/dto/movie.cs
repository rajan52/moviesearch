﻿using System;
using System.Collections.Generic;
using System.Text;

namespace movieSearch.Model.dto
{
    public class movie
    {
        public string Language { get; set; }
        public string Location { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public List<string> SoundEffects { get; set; }
        public List<string> Stills { get; set; }
        public string Title { get; set; }
        public string imdbID { get; set; }
        public string listingType { get; set; }
        public int imdbRating { get; set; }
    }
}
