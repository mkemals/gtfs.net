// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Aktarma (bağlantı) türü.
    /// </summary>
    public enum TransferType
    {
        /// <summary>
        /// 0 - Hatlar arası önerilen aktarma noktası (boş değer de bu anlama gelir).
        /// </summary>
        Recommended = 0,

        /// <summary>
        /// 1 - Zamanlanmış aktarma noktası. Kalkan araç, gelen aracı bekler ve aktarma için yeterli süre bırakır.
        /// </summary>
        Timed = 1,

        /// <summary>
        /// 2 - Aktarma, varış ve kalkış arasında minimum süre gerektirir; süre min_transfer_time ile belirtilir.
        /// </summary>
        MinimumTime = 2,

        /// <summary>
        /// 3 - Bu konumda hatlar arası aktarma mümkün değildir.
        /// </summary>
        NotPossible = 3,

        /// <summary>
        /// 4 - Yolcular aynı araçta kalarak bir seferden diğerine aktarma yapabilir (koltukta aktarma).
        /// </summary>
        InSeat = 4,

        /// <summary>
        /// 5 - Ardışık seferler arasında koltukta aktarmaya izin verilmez; yolcu inip yeniden binmelidir.
        /// </summary>
        InSeatNotAllowed = 5,
    }
}
