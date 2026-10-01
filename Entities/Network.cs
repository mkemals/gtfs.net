// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// Hatların ağ (network) gruplamalarını tanımlar.
    /// routes.txt içinde network_id alanı varsa bu dosya yasaktır.
    /// Birincil anahtar: network_id
    /// </summary>
    [Presence(PresenceType.ConditionallyForbidden)]
    [GtfsFileName("networks")]
    public class Network : AGtfsEntity
    {
        /// <summary>
        /// Bir ağı tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("network_id", PrimaryKey: true, UniqueKey: true)]
        public string NetworkId { get; set; } = string.Empty;

        /// <summary>
        /// Ağın yolculara gösterilen adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("network_name")]
        public string? NetworkName { get; set; }
    }
}
