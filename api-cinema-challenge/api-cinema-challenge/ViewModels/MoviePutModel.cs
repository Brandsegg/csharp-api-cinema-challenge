﻿namespace api_cinema_challenge.ViewModels
{
    public class MoviePutModel
    {
        public string? title { get; set; }

        public string? rating { get; set; }

        public string? description { get; set; }

        public int runtimeMins { get; set; }
    }
}
