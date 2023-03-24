namespace DemoCorso.Business.Northwind;

public interface INorthwindData
{
    IEnumerable<CategoriaDTO> EstraiCategorie();
    Task<IEnumerable<CategoriaDTO>> EstraiCategorieAsync();
    Task<int> CreaCategoriaAsync(CategoriaCreaDTO nuovaCategoria);
    Task<CategoriaDettaglioDTO?> EstraiCategoriaPerIdAsync(int idCategoria);
    Task ModificaCategoria(CategoriaDTO categoriaModificata);
    Task CancellaCategoria(int idCategoria);
}
