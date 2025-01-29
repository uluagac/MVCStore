using System.Text.Json.Serialization;
using Entities.Models;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Models
{
  public class SessionCart : Cart
  {
    [JsonIgnore]
    public ISession? Session { get; set; } // Session'a erişmek için.
    /// <summary>
    /// Servisler üzerinden session'a erişir ve session'ı okur, eğer yoksa yeni nesne üretir.
    /// </summary>
    /// <param name="services">Uygulamanın çalışırken ihtiyaç duyduğu servislere erişim sağlar.</param>
    /// <returns>SessionCart türünde bir cart döner.</returns>
    public static Cart GetCart(IServiceProvider services) // Cart nesnesine erişmek için.
    {
      ISession? session = services.GetRequiredService<IHttpContextAccessor>() // Requestleri, responseları, sessionları üzerinde tutan nesneye erişmek için.
        .HttpContext?.Session; // Nesne üzerindense HttpContext'e ve oradan da Session'a erişmek için.
      SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart(); // session üzerinden GetJson metoduna erişilir.
      cart.Session = session;
      return cart;
    }

    public override void AddItem(Product product, int quantity)
    {
      base.AddItem(product, quantity);
      Session?.SetJson<SessionCart>("cart", this);
    }
    public override void Clear()
    {
      base.Clear();
      Session?.Remove("cart");
    }
    public override void RemoveLine(Product product)
    {
      base.RemoveLine(product);
      Session?.SetJson<SessionCart>("cart", this);
    }
  }
}