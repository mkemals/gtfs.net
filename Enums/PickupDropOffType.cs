// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Durakta yolcu alma/indirme yöntemi.
    /// </summary>
    public enum PickupDropOffType
    {
        /// <summary>
        /// 0 - Düzenli tarifeli alma/indirme (boş değer de bu anlama gelir).
        /// </summary>
        Regular = 0,

        /// <summary>
        /// 1 - Alma/indirme yapılmaz.
        /// </summary>
        None = 1,

        /// <summary>
        /// 2 - Alma/indirme için kurumun aranması gerekir.
        /// </summary>
        PhoneAgency = 2,

        /// <summary>
        /// 3 - Alma/indirme için sürücüyle koordinasyon gerekir.
        /// </summary>
        CoordinateWithDriver = 3,
    }
}
