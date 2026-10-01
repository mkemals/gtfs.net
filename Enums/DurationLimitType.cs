// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Aktarma süre sınırının göreceli başlangıç ve bitişi.
    /// </summary>
    public enum DurationLimitType
    {
        /// <summary>
        /// 0 - Aktarma alt yolculuğunun ilk bacağının kalkış doğrulaması ile son bacağının varış doğrulaması arası.
        /// </summary>
        DepartureToArrival = 0,

        /// <summary>
        /// 1 - İlk bacağın kalkış doğrulaması ile son bacağın kalkış doğrulaması arası.
        /// </summary>
        DepartureToDeparture = 1,

        /// <summary>
        /// 2 - İlk bacağın varış doğrulaması ile son bacağın kalkış doğrulaması arası.
        /// </summary>
        ArrivalToDeparture = 2,

        /// <summary>
        /// 3 - İlk bacağın varış doğrulaması ile son bacağın varış doğrulaması arası.
        /// </summary>
        ArrivalToArrival = 3,
    }
}
