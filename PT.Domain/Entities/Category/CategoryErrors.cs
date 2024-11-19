using PT.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Category
{
    public static class CategoryErrors
    {
        public static Error Null = new("Category.Error", "Enter CategoryName");
        public static Error NullType = new("Category.Nulltype", "Choose a vvalid type");
    }
}
