using System.Text.Json;

namespace StoreApp.Infrastructe.Extensions
{
  public static class SessionExtension // Genellikle extension ifadeler static classlara yazılır ve extension metotlar static olur.
  {
    /// <summary>
    /// 'Object'i Json'a dönüştürmek ve 'session'a kaydetmek için kullanılır.
    /// </summary>
    /// <param name="session">Genişletilecek ifadenin 'type'ı</param>
    /// <param name="key">Session için key (anahtar)</param>
    /// <param name="value">Session için value (değer)</param>
    public static void SetJson(this ISession session, string key, object value) // İlk parametre genişletilen ifadenin 'type'ını tanımlar.
    {
      session.SetString(key, JsonSerializer.Serialize(value));
    }
    /// <summary>
    /// Generic Nesneyi Json'a dönüştürmek ve 'session'a kaydetmek için kullanılır.
    /// </summary>
    /// <typeparam name="T">Generic Nesne</typeparam>
    /// <param name="session">Genişletilecek ifadenin 'type'ı</param>
    /// <param name="key">Session için key (anahtar)</param>
    /// <param name="value">Session için value (değer)</param>
    public static void SetJson<T>(this ISession session, string key, T value)
    {
      session.SetString(key, JsonSerializer.Serialize(value));
    }
    /// <summary>
    /// 'Session'dan okunan nesneyi 'Deserialize' ile 'Generic' bir nesneye çevirir.
    /// </summary>
    /// <typeparam name="T">Generic Nesne</typeparam>
    /// <param name="session">Genişletilecek ifadenin 'type'ı</param>
    /// <param name="key">Session'dan gelmesi istenen key (anahtar)</param>
    /// <returns></returns>
    public static T? GetJson<T>(this ISession session, string key)
    {
      var data = session.GetString(key);
      return data is null ? default(T) : JsonSerializer.Deserialize<T>(data);
    }
  }
}