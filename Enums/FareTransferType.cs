// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Bacaklar arası aktarmanın maliyet hesaplama yöntemi.
    /// </summary>
    public enum FareTransferType
    {
        /// <summary>
        /// 0 - Önceki bacak ücret ürünü + aktarma ücret ürünü; A + AB.
        /// </summary>
        FromLegPlusTransfer = 0,

        /// <summary>
        /// 1 - Önceki bacak ücret ürünü + aktarma ücret ürünü + sonraki bacak ücret ürünü; A + AB + B.
        /// </summary>
        FromLegPlusTransferPlusToLeg = 1,

        /// <summary>
        /// 2 - Yalnızca aktarma ücret ürünü; AB.
        /// </summary>
        TransferOnly = 2,
    }
}
