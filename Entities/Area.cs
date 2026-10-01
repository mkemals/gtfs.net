// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Konumların alan (bölge) gruplamalarını tanımlar.
    /// Birincil anahtar: area_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("areas")]
    public class Area : AGtfsEntity
    {
        /// <summary>
        /// Bir alanı tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("area_id", PrimaryKey: true, UniqueKey: true)]
        public string AreaId { get; set; } = string.Empty;

        /// <summary>
        /// Alanın yolculara gösterilen adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("area_name")]
        public string? AreaName { get; set; }
    }
}
