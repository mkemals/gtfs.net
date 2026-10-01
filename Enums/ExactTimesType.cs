// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Frekans tanımlı seferin hizmet türü.
    /// </summary>
    public enum ExactTimesType
    {
        /// <summary>
        /// 0 - Frekans tabanlı seferler (boş değer de bu anlama gelir).
        /// </summary>
        FrequencyBased = 0,

        /// <summary>
        /// 1 - Gün boyunca tam olarak aynı aralıkla çalışan tarife tabanlı seferler.
        /// </summary>
        ScheduleBased = 1,
    }
}
