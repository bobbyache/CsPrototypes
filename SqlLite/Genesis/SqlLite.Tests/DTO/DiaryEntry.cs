﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.Tests.DTO
{
    [Table("DiaryEntry")]
    public class DiaryEntry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long DateCreated { get; set; }
    }
}
