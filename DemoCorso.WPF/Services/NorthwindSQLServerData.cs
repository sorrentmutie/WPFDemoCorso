using DemoCorso.Business.Northwind;
using DemoCorso.Data.Northwind;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
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

    public async Task CancellaCategoria(int idCategoria)
    {
       var categoryDb = await database.Categories.FindAsync(idCategoria);
        if(categoryDb != null)
        {
            database.Entry(categoryDb).State = EntityState.Deleted;
            await database.SaveChangesAsync();
        }
    }

    public async Task<int> CreaCategoriaAsync(CategoriaCreaDTO nuovaCategoria)
    {
        var category = new Category
        {
            CategoryName = nuovaCategoria.Nome,
            Description = nuovaCategoria.Descrizione
        };
       database.Categories.Add(category);
       await database.SaveChangesAsync();
       return category.CategoryId;
    }

    public async Task<CategoriaDettaglioDTO?> EstraiCategoriaPerIdAsync(int id)
    {
        var category = await 
            database.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.CategoryId == id);

        //if(category != null)
        //{
        //    category.CategoryName = "Modificato2";
        //    category.Description = "Descrizione modificata";
        //    await database.SaveChangesAsync();
        //}

        var data =  new CategoriaDettaglioDTO
        {
            Descrizione = category?.Description,
            Id = category != null ? category.CategoryId : 0,
            Nome = category?.CategoryName,
            Prodotti = 
             category?.Products.Select(p => new ProdottoDettaglioDTO { Id = p.ProductId,
                Name = p.ProductName }).ToList() 
        };

        return data;

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

    public async Task ModificaCategoria(CategoriaDTO categoriaModificata)
    {
        var categoriaDatabase = await
            database.Categories.FindAsync(categoriaModificata.Id);
        if(categoriaDatabase != null)
        {
            database.Entry(categoriaDatabase).State = EntityState.Detached;
            var category = new Category
            {
                CategoryId = categoriaModificata.Id,
                CategoryName = categoriaModificata.Nome
            };
            database.Entry(category).State = EntityState.Modified ;
            await database.SaveChangesAsync();
        }

    }
}
