using Services.Contracts;

namespace Services
{
  public class ServiceManager : IServiceManager
  {
    private readonly IProductService _productService;
    private readonly ICategoryServices _categoryService;
    private readonly IOrderService _orderService;

    public ServiceManager(IProductService productService, ICategoryServices categoryService, IOrderService orderService)
    {
      _productService = productService;
      _categoryService = categoryService;
      _orderService = orderService;
    }

    public IProductService ProductService => _productService;

    public ICategoryServices CategoryService => _categoryService;

    public IOrderService OrderService => _orderService;
  }
}