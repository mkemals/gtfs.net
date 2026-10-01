// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Seferde bisiklet izni.
    /// </summary>
    public enum BikesAllowance
    {
        /// <summary>
        /// 0 - Bisiklet bilgisi yok (veya boş).
        /// </summary>
        NoInformation = 0,

        /// <summary>
        /// 1 - Bu seferde kullanılan araç en az bir bisiklet taşıyabilir.
        /// </summary>
        Allowed = 1,

        /// <summary>
        /// 2 - Bu seferde bisiklete izin verilmez.
        /// </summary>
        NotAllowed = 2,
    }
}
