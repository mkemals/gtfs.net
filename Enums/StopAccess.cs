// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Durağa bir istasyon için nasıl erişildiği.
    /// </summary>
    public enum StopAccess
    {
        /// <summary>
        /// 0 - Durak/perona doğrudan sokak ağından erişilemez; istasyon girişi (yoksa istasyonun kendisi) üzerinden erişilmelidir. Geçitler tanımlıysa kullanılmalıdır.
        /// </summary>
        ViaStation = 0,

        /// <summary>
        /// 1 - Tüketici uygulamalar, üst istasyonun giriş ve geçitlerinden bağımsız olarak doğrudan durağa yol tarifi üretmelidir.
        /// </summary>
        Direct = 1,
    }
}
