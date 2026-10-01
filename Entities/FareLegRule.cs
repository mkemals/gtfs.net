// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Yolculuğun tek tek bacakları (leg) için ücret kurallarını tanımlar.
    /// Ücret yapılarını daha ayrıntılı modellemeyi sağlar ve fare_attributes.txt ile fare_rules.txt dosyalarından tamamen bağımsızdır.
    /// Birincil anahtar: network_id, from_area_id, to_area_id, from_timeframe_group_id, to_timeframe_group_id, fare_product_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("fare_leg_rules")]
    public class FareLegRule : AGtfsEntity
    {
        /// <summary>
        /// Bacak (leg) grubunu tanımlar.
        /// GTFS tipi: ID.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("leg_group_id")]
        public string? LegGroupId { get; set; }

        /// <summary>
        /// Ücret bacak kuralının uygulandığı hat ağını tanımlar. Boşsa varsayılan olarak tüm ağlarla eşleşir.
        /// GTFS tipi: Foreign ID referencing `routes.network_id` or `networks.network_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("network_id", PrimaryKey: true, ForeignKey: true)]
        public string? NetworkId { get; set; }

        /// <summary>
        /// Kalkış alanını tanımlar. Boşsa varsayılan olarak tüm alanlarla eşleşir.
        /// GTFS tipi: Foreign ID referencing `areas.area_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("from_area_id", PrimaryKey: true, ForeignKey: true)]
        public string? FromAreaId { get; set; }

        /// <summary>
        /// Varış alanını tanımlar. Boşsa varsayılan olarak tüm alanlarla eşleşir.
        /// GTFS tipi: Foreign ID referencing `areas.area_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("to_area_id", PrimaryKey: true, ForeignKey: true)]
        public string? ToAreaId { get; set; }

        /// <summary>
        /// Bacak başlangıcındaki ücret geçerlilik zaman dilimini tanımlar.
        /// GTFS tipi: Foreign ID referencing `timeframes.timeframe_group_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("from_timeframe_group_id", PrimaryKey: true, ForeignKey: true)]
        public string? FromTimeframeGroupId { get; set; }

        /// <summary>
        /// Bacak sonundaki ücret geçerlilik zaman dilimini tanımlar.
        /// GTFS tipi: Foreign ID referencing `timeframes.timeframe_group_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("to_timeframe_group_id", PrimaryKey: true, ForeignKey: true)]
        public string? ToTimeframeGroupId { get; set; }

        /// <summary>
        /// Bacağı kullanmak için gereken ücret ürününü tanımlar.
        /// GTFS tipi: Foreign ID referencing `fare_products.fare_product_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("fare_product_id", PrimaryKey: true, ForeignKey: true)]
        public string FareProductId { get; set; } = string.Empty;

        /// <summary>
        /// Eşleşen kuralların hangi sırayla uygulanacağını tanımlar. Yüksek değer öncelikli; boş ise 0 kabul edilir.
        /// GTFS tipi: Non-negative integer.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("rule_priority")]
        [DefaultValue(0)]
        public int RulePriority { get; set; } = 0;
    }
}
