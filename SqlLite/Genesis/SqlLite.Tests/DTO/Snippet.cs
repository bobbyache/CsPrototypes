using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.Tests.DTO
{
    [Table("Snippet")]
    public class Snippet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int SyntaxHighlightId { get; set; }
    }
}
