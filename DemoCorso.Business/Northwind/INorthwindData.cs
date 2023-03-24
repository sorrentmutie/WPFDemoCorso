namespace DemoCorso.Business.Northwind;

public interface INorthwindData
{
    IEnumerable<CategoriaDTO> EstraiCategorie();
    Task<IEnumerable<CategoriaDTO>> EstraiCategorieAsync();
}
