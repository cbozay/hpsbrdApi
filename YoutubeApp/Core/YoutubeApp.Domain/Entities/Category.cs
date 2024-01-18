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

        public  int ParentId { get; set; }
        public  string Name { get; set; }
        public  int Priority { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}

