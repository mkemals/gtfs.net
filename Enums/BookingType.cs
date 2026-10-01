// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Rezervasyonun ne kadar önceden yapılabileceği.
    /// </summary>
    public enum BookingType
    {
        /// <summary>
        /// 0 - Gerçek zamanlı rezervasyon.
        /// </summary>
        RealTime = 0,

        /// <summary>
        /// 1 - Önceden bildirimle aynı gün rezervasyon.
        /// </summary>
        SameDay = 1,

        /// <summary>
        /// 2 - Önceki gün(ler)e kadar rezervasyon.
        /// </summary>
        PriorDays = 2,
    }
}
