// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// Yolcuların satın alabileceği farklı bilet ve ücret türlerini tanımlar.
    /// Bu dosya, fare_attributes.txt ve fare_rules.txt dosyalarından tamamen bağımsızdır.
    /// Birincil anahtar: fare_product_id, rider_category_id, fare_media_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("fare_products")]
    public class FareProduct : AGtfsEntity
    {
        /// <summary>
        /// Bir ücret ürününü veya ücret ürünleri kümesini tanımlar.
        /// GTFS tipi: ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("fare_product_id", PrimaryKey: true)]
        public string FareProductId { get; set; } = string.Empty;

        /// <summary>
        /// Ücret ürününün yolculara gösterilen adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("fare_product_name")]
        public string? FareProductName { get; set; }

        /// <summary>
        /// Ücret ürününden yararlanabilecek yolcu kategorisini tanımlar.
        /// GTFS tipi: Foreign ID referencing `rider_categories.rider_category_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("rider_category_id", PrimaryKey: true, ForeignKey: true)]
        public string? RiderCategoryId { get; set; }

        /// <summary>
        /// Ücret ürününü kullanmak için gereken ödeme aracını tanımlar.
        /// GTFS tipi: Foreign ID referencing `fare_media.fare_media_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("fare_media_id", PrimaryKey: true, ForeignKey: true)]
        public string? FareMediaId { get; set; }

        /// <summary>
        /// Ücret ürününün tutarı. İndirimli aktarma ücretleri için negatif olabilir.
        /// GTFS tipi: Currency amount.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Ücret ürününün para birimi (ISO 4217).
        /// GTFS tipi: Currency code.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("currency")]
        public string Currency { get; set; } = string.Empty;
    }
}
