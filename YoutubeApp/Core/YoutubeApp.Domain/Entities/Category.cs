using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Domain.Common;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Domain.Entities
{
    public class Category:EntityBase
    {
        public Category()
        {

        }
        public Category(int priority,int parentId,string name)
        {

            Priority = priority;
            ParentId = parentId;
            Name = name;
        }

        public required int ParentId { get; set; }
        public required string Name { get; set; }
        public required int Priority { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

