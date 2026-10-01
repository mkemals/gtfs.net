// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// Hatlar arasındaki aktarma noktalarında bağlantı kurma kurallarını tanımlar.
    /// Birincil anahtar: from_stop_id, to_stop_id, from_trip_id, to_trip_id, from_route_id, to_route_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("transfers")]
    public class Transfer : AGtfsEntity
    {
        /// <summary>
        /// Hatlar arası bağlantının başladığı durağı veya istasyonu tanımlar.
        /// Koşul: transfer_type 1, 2 veya 3 ise zorunlu; 4 veya 5 ise isteğe bağlıdır.
        /// GTFS tipi: Foreign ID referencing `stops.stop_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("from_stop_id", PrimaryKey: true, ForeignKey: true)]
        public string? FromStopId { get; set; }

        /// <summary>
        /// Hatlar arası bağlantının sona erdiği durağı veya istasyonu tanımlar.
        /// Koşul: transfer_type 1, 2 veya 3 ise zorunlu; 4 veya 5 ise isteğe bağlıdır.
        /// GTFS tipi: Foreign ID referencing `stops.stop_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("to_stop_id", PrimaryKey: true, ForeignKey: true)]
        public string? ToStopId { get; set; }

        /// <summary>
        /// Bağlantının başladığı hattı tanımlar.
        /// GTFS tipi: Foreign ID referencing `routes.route_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("from_route_id", PrimaryKey: true, ForeignKey: true)]
        public string? FromRouteId { get; set; }

        /// <summary>
        /// Bağlantının sona erdiği hattı tanımlar.
        /// GTFS tipi: Foreign ID referencing `routes.route_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("to_route_id", PrimaryKey: true, ForeignKey: true)]
        public string? ToRouteId { get; set; }

        /// <summary>
        /// Bağlantının başladığı seferi tanımlar.
        /// Koşul: transfer_type 4 veya 5 ise zorunlu, aksi halde isteğe bağlıdır.
        /// GTFS tipi: Foreign ID referencing `trips.trip_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("from_trip_id", PrimaryKey: true, ForeignKey: true)]
        public string? FromTripId { get; set; }

        /// <summary>
        /// Bağlantının sona erdiği seferi tanımlar.
        /// Koşul: transfer_type 4 veya 5 ise zorunlu, aksi halde isteğe bağlıdır.
        /// GTFS tipi: Foreign ID referencing `trips.trip_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("to_trip_id", PrimaryKey: true, ForeignKey: true)]
        public string? ToTripId { get; set; }

        /// <summary>
        /// Belirtilen (from_stop_id, to_stop_id) çifti için bağlantı türünü belirtir. Boş bırakılırsa 0 kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("transfer_type")]
        [DefaultValue(TransferType.Recommended)]
        public TransferType TransferType { get; set; } = TransferType.Recommended;

        /// <summary>
        /// Aktarma için gereken minimum süre (saniye).
        /// Koşul: transfer_type=2 ise zorunlu, aksi halde isteğe bağlıdır.
        /// GTFS tipi: Non-negative integer.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("min_transfer_time")]
        public int? MinTransferTime { get; set; }
    }
}
