using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifictions
{
    public class ProductsFilterSpefication : Specification<Product>    // specifivtion sinifindan miras alinir 
    {
        public ProductsFilterSpefication(int? categoryId, int? brandId)
        {
            if (categoryId != null)
                Query.Where(x => x.CategoryId == categoryId);

            if(brandId != null)
                Query.Where(x=> x.BrandId == brandId);
        }

        public ProductsFilterSpefication(int? categoryId, int? brandId, int skip, int take) : this(categoryId, brandId) // const kopyalama metodu ustediki ctor ru buraya alir 
        {
            Query.Skip(skip).Take(take);
        }
    }
}
