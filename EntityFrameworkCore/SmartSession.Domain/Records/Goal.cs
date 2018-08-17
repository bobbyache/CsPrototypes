using System;

namespace SmartSession.Domain.Records
{
    public class Goal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime TargetCompletionDate { get; set; }
    }
}
