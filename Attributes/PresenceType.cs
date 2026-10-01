// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// GTFS dosya ve alanlarına uygulanan bulunma (presence) koşulları.
    /// </summary>
    public enum PresenceType
    {
        /// <summary>Alan veya dosya veri kümesinde bulunmalı ve her kayıt için geçerli bir değer içermelidir.</summary>
        Required,

        /// <summary>Alan veya dosya veri kümesinden çıkarılabilir.</summary>
        Optional,

        /// <summary>Alan veya dosya, açıklamasında belirtilen koşullarda bulunmalıdır.</summary>
        ConditionallyRequired,

        /// <summary>Alan veya dosya, açıklamasında belirtilen koşullarda bulunmamalıdır.</summary>
        ConditionallyForbidden,

        /// <summary>Alan veya dosya çıkarılabilir, ancak eklenmesi en iyi uygulamadır.</summary>
        Recommended,
    }
}
