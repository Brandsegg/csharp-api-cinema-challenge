﻿using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.ViewModels
{
    public class ScreeningPostModel
    {
        public int ScreenNumber { get; set; }
        public int Capacity { get; set; }
        public DateTime StartsAt { get; set; }
    }
}
