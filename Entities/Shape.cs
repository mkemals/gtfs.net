// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// Araçların izlediği güzergah geometrisinin (hat hizalaması) eşleme kurallarını tanımlar.
    /// Seferde routes.txt veya stop_times.txt içinde sürekli yolcu alma/indirme davranışı tanımlanmışsa zorunludur, aksi halde önerilir.
    /// Birincil anahtar: shape_id, shape_pt_sequence
    /// </summary>
    [Presence(PresenceType.ConditionallyRequired)]
    [GtfsFileName("shapes")]
    public class Shape : AGtfsEntity
    {
        /// <summary>
        /// Bir şekli (güzergah geometrisini) tanımlar.
        /// GTFS tipi: ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("shape_id", PrimaryKey: true)]
        public string ShapeId { get; set; } = string.Empty;

        /// <summary>
        /// Şekil noktasının enlemi.
        /// GTFS tipi: Latitude.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("shape_pt_lat")]
        public double ShapePtLat { get; set; }

        /// <summary>
        /// Şekil noktasının boylamı.
        /// GTFS tipi: Longitude.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("shape_pt_lon")]
        public double ShapePtLon { get; set; }

        /// <summary>
        /// Şekil noktalarının birleştirilerek şeklin oluşturulma sırası. Sefer boyunca artmalıdır.
        /// GTFS tipi: Non-negative integer.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("shape_pt_sequence", PrimaryKey: true)]
        public int ShapePtSequence { get; set; }

        /// <summary>
        /// İlk şekil noktasından bu noktaya kadar şekil boyunca kat edilen gerçek mesafe.
        /// GTFS tipi: Non-negative float.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("shape_dist_traveled")]
        public double? ShapeDistTraveled { get; set; }
    }
}
