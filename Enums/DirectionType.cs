// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Seferin yönü.
    /// </summary>
    public enum DirectionType
    {
        /// <summary>
        /// 0 - Bir yönde seyahat (ör. gidiş).
        /// </summary>
        OneDirection = 0,

        /// <summary>
        /// 1 - Ters yönde seyahat (ör. dönüş).
        /// </summary>
        OppositeDirection = 1,
    }
}
