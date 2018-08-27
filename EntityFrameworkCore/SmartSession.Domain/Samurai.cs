using System;
using System.Collections.Generic;

namespace SmartSession.Domain
{
    public class Samurai
    {
        public Samurai()
        {
            Quotes = new List<Quote>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; }
        List<SamuraiBattle> SamuraiBattles { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
    }

    public class Quote
    {
        public int Id { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }

    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SamuraiBattle> SamuraiBattles { get; set; }
    }

    public class SamuraiBattle
    {
        public int BattleIdId { get; set; }
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }
    }

    public class SecretIdentity
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public int SamuraiId { get; set; }
    }
}
