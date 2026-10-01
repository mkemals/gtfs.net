// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Geçidin kullanılabileceği yön.
    /// </summary>
    public enum PathwayDirection
    {
        /// <summary>
        /// 0 - Yalnızca from_stop_id'den to_stop_id'ye kullanılabilen tek yönlü geçit.
        /// </summary>
        Unidirectional = 0,

        /// <summary>
        /// 1 - Her iki yönde kullanılabilen çift yönlü geçit.
        /// </summary>
        Bidirectional = 1,
    }
}
