using System;
using System.Collections.Generic;

namespace WCBackend.model
{
    public partial class Entry
    {
        public int Id { get; set; }
        public string Results { get; set; } = null!;
    }
}
