// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// fare_leg_rules.txt kurallarıyla eşleştirme amacıyla iki veya daha fazla bacağın tek bir "etkin ücret bacağı" olarak değerlendirilmesine ilişkin kuralları tanımlar.
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("fare_leg_join_rules")]
    public class FareLegJoinRule : AGtfsEntity
    {
        /// <summary>
        /// Aktarma öncesi bacağın ağıyla eşleşir.
        /// GTFS tipi: Foreign ID referencing `routes.network_id` or `networks.network_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("from_network_id", ForeignKey: true)]
        public string FromNetworkId { get; set; } = string.Empty;

        /// <summary>
        /// Aktarma sonrası bacağın ağıyla eşleşir.
        /// GTFS tipi: Foreign ID referencing `routes.network_id` or `networks.network_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("to_network_id", ForeignKey: true)]
        public string ToNetworkId { get; set; } = string.Empty;

        /// <summary>
        /// Belirtilen durakta veya istasyonda sona eren aktarma öncesi bacakla eşleşir.
        /// Koşul: to_stop_id tanımlıysa zorunlu, aksi halde isteğe bağlıdır.
        /// GTFS tipi: Foreign ID referencing `stops.stop_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("from_stop_id", ForeignKey: true)]
        public string? FromStopId { get; set; }

        /// <summary>
        /// Belirtilen durakta veya istasyonda başlayan aktarma sonrası bacakla eşleşir.
        /// Koşul: from_stop_id tanımlıysa zorunlu, aksi halde isteğe bağlıdır.
        /// GTFS tipi: Foreign ID referencing `stops.stop_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("to_stop_id", ForeignKey: true)]
        public string? ToStopId { get; set; }
    }
}
