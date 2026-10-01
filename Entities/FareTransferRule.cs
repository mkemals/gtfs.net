// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// Yolculuk bacakları arasındaki aktarmalara ilişkin ücret kurallarını tanımlar.
    /// fare_leg_rules.txt ile birlikte ücret yapılarını ayrıntılı modellemeyi sağlar ve fare_attributes.txt ile fare_rules.txt dosyalarından tamamen bağımsızdır.
    /// Birincil anahtar: from_leg_group_id, to_leg_group_id, fare_product_id, transfer_count, duration_limit
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("fare_transfer_rules")]
    public class FareTransferRule : AGtfsEntity
    {
        /// <summary>
        /// Aktarma öncesi ücret bacağı grubunu tanımlar. Boşsa varsayılan olarak tümüyle eşleşir.
        /// GTFS tipi: Foreign ID referencing `fare_leg_rules.leg_group_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("from_leg_group_id", PrimaryKey: true, ForeignKey: true)]
        public string? FromLegGroupId { get; set; }

        /// <summary>
        /// Aktarma sonrası ücret bacağı grubunu tanımlar. Boşsa varsayılan olarak tümüyle eşleşir.
        /// GTFS tipi: Foreign ID referencing `fare_leg_rules.leg_group_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("to_leg_group_id", PrimaryKey: true, ForeignKey: true)]
        public string? ToLegGroupId { get; set; }

        /// <summary>
        /// Aktarma kuralının uygulanabileceği ardışık aktarma sayısı. -1 sınırsız anlamına gelir; 1 veya daha büyük değerler kuralın kapsayabileceği aktarma sayısıdır.
        /// Koşul: from_leg_group_id ile to_leg_group_id eşitse zorunlu, değilse yasaktır.
        /// GTFS tipi: Non-zero integer.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("transfer_count", PrimaryKey: true)]
        public int? TransferCount { get; set; }

        /// <summary>
        /// Aktarmanın süre sınırı (saniye). Boşsa süre sınırı yoktur.
        /// GTFS tipi: Positive integer.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("duration_limit", PrimaryKey: true)]
        public int? DurationLimit { get; set; }

        /// <summary>
        /// duration_limit süresinin göreceli başlangıç ve bitişini tanımlar.
        /// Koşul: duration_limit tanımlıysa zorunlu, boşsa yasaktır.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("duration_limit_type")]
        public DurationLimitType? DurationLimitType { get; set; }

        /// <summary>
        /// Yolculuktaki bacaklar arası aktarmanın maliyet hesaplama yöntemini belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("fare_transfer_type")]
        public FareTransferType FareTransferType { get; set; }

        /// <summary>
        /// Bacaklar arası aktarma için gereken ücret ürününü tanımlar. Boşsa aktarmanın maliyeti 0'dır.
        /// GTFS tipi: Foreign ID referencing `fare_products.fare_product_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("fare_product_id", PrimaryKey: true, ForeignKey: true)]
        public string? FareProductId { get; set; }
    }
}
