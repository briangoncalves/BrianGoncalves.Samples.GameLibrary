using System;

namespace Models
{
    public class Game
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
