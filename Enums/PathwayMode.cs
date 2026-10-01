// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Geçit türü.
    /// </summary>
    public enum PathwayMode
    {
        /// <summary>
        /// 1 - Yürüyüş yolu.
        /// </summary>
        Walkway = 1,

        /// <summary>
        /// 2 - Merdiven.
        /// </summary>
        Stairs = 2,

        /// <summary>
        /// 3 - Yürüyen yol (travelatör).
        /// </summary>
        MovingSidewalk = 3,

        /// <summary>
        /// 4 - Yürüyen merdiven.
        /// </summary>
        Escalator = 4,

        /// <summary>
        /// 5 - Asansör.
        /// </summary>
        Elevator = 5,

        /// <summary>
        /// 6 - Ücret (ödeme) kapısı: Geçmek için ödeme kanıtı gereken istasyon alanına giriş yapan geçit.
        /// </summary>
        FareGate = 6,

        /// <summary>
        /// 7 - Çıkış kapısı: Ücretli alandan, geçmek için ödeme kanıtı gerekmeyen ücretsiz alana çıkan geçit.
        /// </summary>
        ExitGate = 7,
    }
}
