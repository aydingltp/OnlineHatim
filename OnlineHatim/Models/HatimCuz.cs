﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace OnlineHatim.Models
{
    public class HatimCuz
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public int CuzNo { get; set; }

        [JsonIgnore]
        public Hatim Hatim { get; set; }


    }
}
