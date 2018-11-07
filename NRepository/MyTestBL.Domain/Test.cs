using System;
using System.Collections.Generic;

namespace NRepository.MyTestBL.Domain
{
    public class Test
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public List<TestItem> TestItems { get; set; }
        public DateTimeOffset TestDate { get; set; }
    }
}