// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Güzergahlara ücretlerin uygulanma kurallarını tanımlar.
    /// Birincil anahtar: tüm alanlar (*)
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("fare_rules")]
    public class FareRule : AGtfsEntity
    {
        /// <summary>
        /// Bir ücret sınıfını tanımlar.
        /// GTFS tipi: Foreign ID referencing `fare_attributes.fare_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("fare_id", PrimaryKey: true, ForeignKey: true)]
        public string FareId { get; set; } = string.Empty;

        /// <summary>
        /// Ücret sınıfıyla ilişkilendirilen hattı tanımlar.
        /// GTFS tipi: Foreign ID referencing `routes.route_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("route_id", PrimaryKey: true, ForeignKey: true)]
        public string? RouteId { get; set; }

        /// <summary>
        /// Kalkış bölgesini tanımlar.
        /// GTFS tipi: Foreign ID referencing `stops.zone_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("origin_id", PrimaryKey: true, ForeignKey: true)]
        public string? OriginId { get; set; }

        /// <summary>
        /// Varış bölgesini tanımlar.
        /// GTFS tipi: Foreign ID referencing `stops.zone_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("destination_id", PrimaryKey: true, ForeignKey: true)]
        public string? DestinationId { get; set; }

        /// <summary>
        /// Yolcunun belirli bir güzergah sırasında geçeceği bölgeleri tanımlar.
        /// GTFS tipi: Foreign ID referencing `stops.zone_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("contains_id", PrimaryKey: true, ForeignKey: true)]
        public string? ContainsId { get; set; }
    }
}
