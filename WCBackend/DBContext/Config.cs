using System;
using System.Collections.Generic;

namespace WCBackend.DBContext
{
    public partial class Config
    {
        public int Id { get; set; }
        public string Results { get; set; } = null!;
    }
}
