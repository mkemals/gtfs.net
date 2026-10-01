// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// Hatları ağlara atama kurallarını tanımlar.
    /// routes.txt içinde network_id alanı varsa bu dosya yasaktır.
    /// Birincil anahtar: route_id
    /// </summary>
    [Presence(PresenceType.ConditionallyForbidden)]
    [GtfsFileName("route_networks")]
    public class RouteNetwork : AGtfsEntity
    {
        /// <summary>
        /// Bir veya daha fazla route_id'nin ait olduğu ağı tanımlar.
        /// GTFS tipi: Foreign ID referencing `networks.network_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("network_id", ForeignKey: true)]
        public string NetworkId { get; set; } = string.Empty;

        /// <summary>
        /// Bir hattı tanımlar.
        /// GTFS tipi: Foreign ID referencing `routes.route_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("route_id", PrimaryKey: true, ForeignKey: true)]
        public string RouteId { get; set; } = string.Empty;
    }
}
