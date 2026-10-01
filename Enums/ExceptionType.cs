// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Hizmet istisnası türü.
    /// </summary>
    public enum ExceptionType
    {
        /// <summary>
        /// 1 - Belirtilen tarih için hizmet eklenmiştir.
        /// </summary>
        Added = 1,

        /// <summary>
        /// 2 - Belirtilen tarih için hizmet kaldırılmıştır.
        /// </summary>
        Removed = 2,
    }
}
