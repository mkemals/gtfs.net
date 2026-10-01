// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Temassız EMV (cEMV) desteği.
    /// </summary>
    public enum CemvSupport
    {
        /// <summary>
        /// 0 - cEMV bilgisi yok (veya boş).
        /// </summary>
        NoInformation = 0,

        /// <summary>
        /// 1 - Yolcular cEMV'yi ödeme aracı olarak kullanabilir.
        /// </summary>
        Supported = 1,

        /// <summary>
        /// 2 - cEMV ödeme aracı olarak desteklenmez.
        /// </summary>
        NotSupported = 2,
    }
}
