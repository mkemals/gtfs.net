// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Konumdan tekerlekli sandalyeyle biniş durumu. Anlamı konum türüne göre değişir (üst istasyonu olmayan durak, alt durak, istasyon girişi).
    /// </summary>
    public enum WheelchairBoarding
    {
        /// <summary>
        /// 0 - Bilgi yok (veya boş). Alt duraklar ve girişler için üst istasyonun değeri devralınır.
        /// </summary>
        NoInformation = 0,

        /// <summary>
        /// 1 - Bu duraktaki bazı araçlara tekerlekli sandalyeyle binilebilir / istasyon dışından durağa erişilebilir bir yol vardır / giriş erişilebilirdir.
        /// </summary>
        Accessible = 1,

        /// <summary>
        /// 2 - Tekerlekli sandalyeyle biniş mümkün değildir / erişilebilir yol yoktur.
        /// </summary>
        NotAccessible = 2,
    }
}
