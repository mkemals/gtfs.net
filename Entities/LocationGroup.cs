// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Yolcunun alınma veya indirilme talebinde bulunabileceği konumları birlikte belirten durak gruplarını tanımlar.
    /// Birincil anahtar: location_group_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("location_groups")]
    public class LocationGroup : AGtfsEntity
    {
        /// <summary>
        /// Bir konum grubunu tanımlar. stops.stop_id, locations.geojson id ve location_group_id değerleri arasında benzersiz olmalıdır.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("location_group_id", PrimaryKey: true, UniqueKey: true)]
        public string LocationGroupId { get; set; } = string.Empty;

        /// <summary>
        /// Konum grubunun yolculara gösterilen adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("location_group_name")]
        public string? LocationGroupName { get; set; }
    }
}
