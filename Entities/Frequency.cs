// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Sefer aralığına (headway) dayalı hizmetler için seferler arası süreyi veya sabit tarifeli hizmetin sıkıştırılmış gösterimini tanımlar.
    /// Birincil anahtar: trip_id, start_time
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("frequencies")]
    public class Frequency : AGtfsEntity
    {
        /// <summary>
        /// Belirtilen sefer aralığının uygulandığı seferi tanımlar.
        /// GTFS tipi: Foreign ID referencing `trips.trip_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("trip_id", PrimaryKey: true, ForeignKey: true)]
        public string TripId { get; set; } = string.Empty;

        /// <summary>
        /// Belirtilen sefer aralığıyla hizmetin ilk aracının kalkış zamanı.
        /// GTFS tipi: Time.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("start_time", PrimaryKey: true)]
        public string StartTime { get; set; } = string.Empty;

        /// <summary>
        /// Hizmetin farklı bir sefer aralığına geçtiği (veya sona erdiği) zaman.
        /// GTFS tipi: Time.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("end_time")]
        public string EndTime { get; set; } = string.Empty;

        /// <summary>
        /// Aynı duraktan kalkışlar arasındaki süre (saniye).
        /// GTFS tipi: Positive integer.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("headway_secs")]
        public int HeadwaySecs { get; set; }

        /// <summary>
        /// Sefer için hizmet türünü belirtir. Boş bırakılırsa 0 (frekans tabanlı) kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("exact_times")]
        [DefaultValue(ExactTimesType.FrequencyBased)]
        public ExactTimesType ExactTimes { get; set; } = ExactTimesType.FrequencyBased;
    }
}
