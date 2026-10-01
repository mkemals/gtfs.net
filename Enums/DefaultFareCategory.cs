// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Yolcu kategorisinin varsayılan olup olmadığı.
    /// </summary>
    public enum DefaultFareCategory
    {
        /// <summary>
        /// 0 - Kategori varsayılan kabul edilmez (veya boş).
        /// </summary>
        NotDefault = 0,

        /// <summary>
        /// 1 - Kategori varsayılan kabul edilir.
        /// </summary>
        Default = 1,
    }
}
