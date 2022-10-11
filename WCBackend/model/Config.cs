using System;
using System.Collections.Generic;

namespace WCBackend.model
{
    public partial class Config
    {
        public int Id { get; set; }
        public string Apikey { get; set; } = null!;
    }
}
