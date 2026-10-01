// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Ücretin ödenme zamanı.
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// 0 - Ücret araçta ödenir.
        /// </summary>
        OnBoard = 0,

        /// <summary>
        /// 1 - Ücret binmeden önce ödenmelidir.
        /// </summary>
        BeforeBoarding = 1,
    }
}
