// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Varış/kalkış zamanlarının kesinliği.
    /// </summary>
    public enum TimepointType
    {
        /// <summary>
        /// 0 - Zamanlar yaklaşıktır.
        /// </summary>
        Approximate = 0,

        /// <summary>
        /// 1 - Zamanlar kesindir.
        /// </summary>
        Exact = 1,
    }
}
