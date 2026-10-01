// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace GtfsNet
{
    /// <summary>
    /// Ödeme aracı türü.
    /// </summary>
    public enum FareMediaType
    {
        /// <summary>
        /// 0 - Yok. Ücret ürününün satın alınmasında veya doğrulanmasında ödeme aracı kullanılmaz (ör. sürücüye nakit ödeme, fiziksel bilet verilmez).
        /// </summary>
        None = 0,

        /// <summary>
        /// 1 - Belirli sayıda önceden satın alınmış yolculuğa veya sabit bir süre içinde sınırsız yolculuğa izin veren fiziksel kâğıt bilet.
        /// </summary>
        PhysicalPaperTicket = 1,

        /// <summary>
        /// 2 - Bilet, abonman veya parasal değer saklayan fiziksel ulaşım kartı.
        /// </summary>
        PhysicalTransitCard = 2,

        /// <summary>
        /// 3 - Hesap tabanlı biletleme için açık döngü belirteci olarak cEMV (temassız Europay, Mastercard ve Visa).
        /// </summary>
        Cemv = 3,

        /// <summary>
        /// 4 - Sanal ulaşım kartı, bilet, abonman veya parasal değer saklayan mobil uygulama.
        /// </summary>
        MobileApp = 4,
    }
}
