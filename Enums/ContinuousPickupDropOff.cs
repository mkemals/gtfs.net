// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Güzergah boyunca sürekli yolcu alma/indirme davranışı.
    /// </summary>
    public enum ContinuousPickupDropOff
    {
        /// <summary>
        /// 0 - Sürekli alma/indirme yapılır.
        /// </summary>
        Continuous = 0,

        /// <summary>
        /// 1 - Sürekli alma/indirme yapılmaz (boş değer de bu anlama gelir).
        /// </summary>
        NotContinuous = 1,

        /// <summary>
        /// 2 - Sürekli alma/indirme için kurumun aranması gerekir.
        /// </summary>
        PhoneAgency = 2,

        /// <summary>
        /// 3 - Sürekli alma/indirme için sürücüyle koordinasyon gerekir.
        /// </summary>
        CoordinateWithDriver = 3,
    }
}
