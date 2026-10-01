// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Durakları konum gruplarına atama kurallarını tanımlar.
    /// Birincil anahtar: tüm alanlar (*)
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("location_group_stops")]
    public class LocationGroupStop : AGtfsEntity
    {
        /// <summary>
        /// Bir veya daha fazla stop_id'nin ait olduğu konum grubunu tanımlar.
        /// GTFS tipi: Foreign ID referencing `location_groups.location_group_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("location_group_id", PrimaryKey: true, ForeignKey: true)]
        public string LocationGroupId { get; set; } = string.Empty;

        /// <summary>
        /// Konum grubuna ait durağı tanımlar.
        /// GTFS tipi: Foreign ID referencing `stops.stop_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("stop_id", PrimaryKey: true, ForeignKey: true)]
        public string StopId { get; set; } = string.Empty;
    }
}
