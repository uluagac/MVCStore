using Services.Contracts;

namespace Services
{
  public class ServiceManager : IServiceManager
  {
    private readonly IProductService _productService;
    private readonly ICategoryServices _categoryService;
    private readonly IOrderService _orderService;
    private readonly IAuthService _authService;

    public ServiceManager(IProductService productService, ICategoryServices categoryService, IOrderService orderService, IAuthService authService)
    {
      _productService = productService;
      _categoryService = categoryService;
      _orderService = orderService;
      _authService = authService;
    }

    public IProductService ProductService => _productService;

    public ICategoryServices CategoryService => _categoryService;

    public IOrderService OrderService => _orderService;

    public IAuthService AuthService => _authService;
  }
}