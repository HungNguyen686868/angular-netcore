using multipleTable.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace multipleTable.Models
{
    public class Category
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public Status Status { set; get; }
    }
}
