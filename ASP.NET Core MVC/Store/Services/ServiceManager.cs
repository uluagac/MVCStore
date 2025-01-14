using Services.Contracts;

namespace Services
{
  public class ServiceManager : IServiceManager
  {
    private readonly IProductService _productService;
    private readonly ICategoryServices _categoryService;

    public ServiceManager(IProductService productService, ICategoryServices categoryService)
    {
      _productService = productService;
      _categoryService = categoryService;
    }

    public IProductService ProductService => _productService;

    public ICategoryServices CategoryServices => _categoryService;
  }
}