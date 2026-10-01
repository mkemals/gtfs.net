// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// İstasyonlar içindeki konumları birbirine bağlayan yaya yollarını (geçitleri) tanımlar.
    /// Birincil anahtar: pathway_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("pathways")]
    public class Pathway : AGtfsEntity
    {
        /// <summary>
        /// Bir geçidi (yaya yolunu) tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("pathway_id", PrimaryKey: true, UniqueKey: true)]
        public string PathwayId { get; set; } = string.Empty;

        /// <summary>
        /// Geçidin başladığı konum.
        /// GTFS tipi: Foreign ID referencing `stops.stop_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("from_stop_id", ForeignKey: true)]
        public string FromStopId { get; set; } = string.Empty;

        /// <summary>
        /// Geçidin sona erdiği konum.
        /// GTFS tipi: Foreign ID referencing `stops.stop_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("to_stop_id", ForeignKey: true)]
        public string ToStopId { get; set; } = string.Empty;

        /// <summary>
        /// Belirtilen (from_stop_id, to_stop_id) çifti arasındaki geçit türü.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("pathway_mode")]
        public PathwayMode PathwayMode { get; set; }

        /// <summary>
        /// Geçidin hangi yönde kullanılabileceğini belirtir. Çıkış kapıları (pathway_mode=7) çift yönlü olamaz.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("is_bidirectional")]
        public PathwayDirection IsBidirectional { get; set; }

        /// <summary>
        /// Geçidin başlangıç ve bitiş noktası arasındaki yatay uzunluk (metre).
        /// GTFS tipi: Non-negative float.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("length")]
        public double? Length { get; set; }

        /// <summary>
        /// Geçidi geçmek için gereken ortalama süre (saniye).
        /// GTFS tipi: Positive integer.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("traversal_time")]
        public int? TraversalTime { get; set; }

        /// <summary>
        /// Geçitteki basamak sayısı. Pozitif değerler yukarı, negatif değerler aşağı yönü belirtir.
        /// GTFS tipi: Non-null integer.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("stair_count")]
        public int? StairCount { get; set; }

        /// <summary>
        /// Geçidin maksimum eğim oranı. 0 veya boş eğim yok; pozitif değerler yukarı, negatif değerler aşağı eğimi belirtir.
        /// GTFS tipi: Float.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("max_slope")]
        [DefaultValue(0.0)]
        public double MaxSlope { get; set; } = 0.0;

        /// <summary>
        /// Geçidin minimum genişliği (metre).
        /// GTFS tipi: Positive float.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("min_width")]
        public double? MinWidth { get; set; }

        /// <summary>
        /// Yolcuların görebildiği tabelalardaki metin.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("signposted_as")]
        public string? SignpostedAs { get; set; }

        /// <summary>
        /// Ters yönde kullanıldığında görülen tabelalardaki metin.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("reversed_signposted_as")]
        public string? ReversedSignpostedAs { get; set; }
    }
}
