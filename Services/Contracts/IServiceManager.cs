namespace Services.Contracts
{
  public interface IServiceManager
  {
    IProductService ProductService { get; }
    ICategoryServices CategoryService { get; }
    IOrderService OrderService { get; }
    IAuthService AuthService { get; }
  }
}