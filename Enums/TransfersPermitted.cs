// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Ücretle izin verilen aktarma sayısı. Değer boşsa (null) sınırsız aktarmaya izin verilir.
    /// </summary>
    public enum TransfersPermitted
    {
        /// <summary>
        /// 0 - Bu ücretle aktarmaya izin verilmez.
        /// </summary>
        NoTransfers = 0,

        /// <summary>
        /// 1 - Yolcular bir kez aktarma yapabilir.
        /// </summary>
        Once = 1,

        /// <summary>
        /// 2 - Yolcular iki kez aktarma yapabilir.
        /// </summary>
        Twice = 2,
    }
}
