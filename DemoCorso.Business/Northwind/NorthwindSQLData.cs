using DemoCorso.Data.Northwind;
using Microsoft.EntityFrameworkCore;

namespace DemoCorso.Business.Northwind;

public class NorthwindSQLData : INorthwindData
{
    private readonly NorthwindContext context;

    public NorthwindSQLData(NorthwindContext context)
    {
        this.context = context;
    }
    public IEnumerable<CategoriaDTO> EstraiCategorie()
    {
        return context.Categories.Select( x => new CategoriaDTO
        {
             Id = x.CategoryId, Name = x.CategoryName, NumeroProdotti = x.Products.Count()
        });
    }
    public async Task<IEnumerable<CategoriaDTO>> EstraiCategorieAsync()
    {
        return await context.Categories.Select(x => new CategoriaDTO
        {
            Id = x.CategoryId,
            Name = x.CategoryName,
            NumeroProdotti = x.Products.Count()
        }).ToListAsync();
    }
}
