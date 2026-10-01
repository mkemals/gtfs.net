// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Kuruluşun ilgili role sahip olup olmadığı.
    /// </summary>
    public enum AttributionRole
    {
        /// <summary>
        /// 0 - Kuruluş bu role sahip değildir (veya boş).
        /// </summary>
        No = 0,

        /// <summary>
        /// 1 - Kuruluş bu role sahiptir.
        /// </summary>
        Yes = 1,
    }
}
