// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Seferde tekerlekli sandalye erişilebilirliği.
    /// </summary>
    public enum WheelchairAccessibility
    {
        /// <summary>
        /// 0 - Erişilebilirlik bilgisi yok (veya boş).
        /// </summary>
        NoInformation = 0,

        /// <summary>
        /// 1 - Bu seferde kullanılan araç en az bir tekerlekli sandalyeli yolcuyu taşıyabilir.
        /// </summary>
        Accessible = 1,

        /// <summary>
        /// 2 - Bu seferde tekerlekli sandalyeli yolcu taşınamaz.
        /// </summary>
        NotAccessible = 2,
    }
}
