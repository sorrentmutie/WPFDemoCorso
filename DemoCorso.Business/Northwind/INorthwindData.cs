namespace DemoCorso.Business.Northwind;

public interface INorthwindData
{
    public IEnumerable<CategoriaDTO> EstraiCategorie();
    public Task<IEnumerable<CategoriaDTO>> EstraiCategorieAsync();
}
