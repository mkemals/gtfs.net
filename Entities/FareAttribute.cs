// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Bir ulaşım kurumunun hatlarına ait ücret bilgilerini tanımlar.
    /// Birincil anahtar: fare_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("fare_attributes")]
    public class FareAttribute : AGtfsEntity
    {
        /// <summary>
        /// Bir ücret sınıfını tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("fare_id", PrimaryKey: true, UniqueKey: true)]
        public string FareId { get; set; } = string.Empty;

        /// <summary>
        /// Ücret tutarı (currency_type ile belirtilen para biriminde).
        /// GTFS tipi: Non-negative float.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Ücretin ödendiği para birimi (ISO 4217).
        /// GTFS tipi: Currency code.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("currency_type")]
        public string CurrencyType { get; set; } = string.Empty;

        /// <summary>
        /// Ücretin ne zaman ödenmesi gerektiğini belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Bu ücretle izin verilen aktarma sayısı. Boş (null) ise sınırsız aktarmaya izin verilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("transfers")]
        public TransfersPermitted Transfers { get; set; }

        /// <summary>
        /// Ücretin ait olduğu kurumu tanımlar.
        /// Koşul: agency.txt içinde birden fazla kurum varsa zorunlu, aksi halde önerilir.
        /// GTFS tipi: Foreign ID referencing `agency.agency_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("agency_id", ForeignKey: true)]
        public string? AgencyId { get; set; }

        /// <summary>
        /// Bir aktarmanın sona ermesine kadar geçen süre (saniye).
        /// GTFS tipi: Non-negative integer.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("transfer_duration")]
        public int? TransferDuration { get; set; }
    }
}
