// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Seferde otomobil izni.
    /// </summary>
    public enum CarsAllowance
    {
        /// <summary>
        /// 0 - Otomobil bilgisi yok (veya boş).
        /// </summary>
        NoInformation = 0,

        /// <summary>
        /// 1 - Bu seferde kullanılan araç en az bir otomobil taşıyabilir.
        /// </summary>
        Allowed = 1,

        /// <summary>
        /// 2 - Bu seferde otomobile izin verilmez.
        /// </summary>
        NotAllowed = 2,
    }
}
