using DemoCorso.Business.Northwind;
using DemoCorso.Data.Northwind;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCorso.Services;

public class NorthwindSQLServerData : INorthwindData
{
    private readonly NorthwindContext database;

    public NorthwindSQLServerData(NorthwindContext database)
    {
        this.database = database;
    }

    public IEnumerable<CategoriaDTO> EstraiCategorie()
    {
         return  database.Categories.Select( c => new CategoriaDTO
            {
                Id = c.CategoryId, Nome = c.CategoryName, NumeroProdotti = c.Products.Count()
            });
    }

    public async Task<IEnumerable<CategoriaDTO>> EstraiCategorieAsync()
    {
        return await database.Categories.Select(c => new CategoriaDTO
        {
            Id = c.CategoryId,
            Nome = c.CategoryName,
            NumeroProdotti = c.Products.Count()
        }).ToListAsync(); 
    }
}
