// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Veri kümesine katkıda bulunan kuruluşları (atıfları) tanımlar.
    /// Birincil anahtar: attribution_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("attributions")]
    public class Attribution : AGtfsEntity
    {
        /// <summary>
        /// Veri kümesindeki bir atfı tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("attribution_id", PrimaryKey: true, UniqueKey: true)]
        public string? AttributionId { get; set; }

        /// <summary>
        /// Atfın uygulandığı kurum.
        /// GTFS tipi: Foreign ID referencing `agency.agency_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("agency_id", ForeignKey: true)]
        public string? AgencyId { get; set; }

        /// <summary>
        /// Atfın uygulandığı hat.
        /// GTFS tipi: Foreign ID referencing `routes.route_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("route_id", ForeignKey: true)]
        public string? RouteId { get; set; }

        /// <summary>
        /// Atfın uygulandığı sefer.
        /// GTFS tipi: Foreign ID referencing `trips.trip_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("trip_id", ForeignKey: true)]
        public string? TripId { get; set; }

        /// <summary>
        /// Veri kümesinin atfedildiği kuruluşun adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("organization_name")]
        public string OrganizationName { get; set; } = string.Empty;

        /// <summary>
        /// Kuruluşun veri üreticisi rolüne sahip olup olmadığı. Boş bırakılırsa 0 kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("is_producer")]
        [DefaultValue(AttributionRole.No)]
        public AttributionRole IsProducer { get; set; } = AttributionRole.No;

        /// <summary>
        /// Kuruluşun işletmeci rolüne sahip olup olmadığı. Boş bırakılırsa 0 kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("is_operator")]
        [DefaultValue(AttributionRole.No)]
        public AttributionRole IsOperator { get; set; } = AttributionRole.No;

        /// <summary>
        /// Kuruluşun yetkili makam rolüne sahip olup olmadığı. Boş bırakılırsa 0 kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("is_authority")]
        [DefaultValue(AttributionRole.No)]
        public AttributionRole IsAuthority { get; set; } = AttributionRole.No;

        /// <summary>
        /// Kuruluşun web adresi.
        /// GTFS tipi: URL.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("attribution_url")]
        public string? AttributionUrl { get; set; }

        /// <summary>
        /// Kuruluşun e-posta adresi.
        /// GTFS tipi: Email.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("attribution_email")]
        public string? AttributionEmail { get; set; }

        /// <summary>
        /// Kuruluşun telefon numarası.
        /// GTFS tipi: Phone number.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("attribution_phone")]
        public string? AttributionPhone { get; set; }
    }
}
