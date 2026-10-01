// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Durakları alanlara atama kurallarını tanımlar.
    /// Birincil anahtar: tüm alanlar (*)
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("stop_areas")]
    public class StopArea : AGtfsEntity
    {
        /// <summary>
        /// Bir veya daha fazla stop_id'nin ait olduğu alanı tanımlar.
        /// GTFS tipi: Foreign ID referencing `areas.area_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("area_id", PrimaryKey: true, ForeignKey: true)]
        public string AreaId { get; set; } = string.Empty;

        /// <summary>
        /// Bir durağı tanımlar. İstasyon verilirse istasyonun tüm perronları da alana dahil kabul edilir.
        /// GTFS tipi: Foreign ID referencing `stops.stop_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("stop_id", PrimaryKey: true, ForeignKey: true)]
        public string StopId { get; set; } = string.Empty;
    }
}
