// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// Tarih ve saate bağlı ücretlerde, ücret kurallarında kullanılacak tarih ve zaman aralıklarını tanımlar.
    /// Birincil anahtar: tüm alanlar (*)
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("timeframes")]
    public class Timeframe : AGtfsEntity
    {
        /// <summary>
        /// Bir zaman dilimi veya zaman dilimleri kümesini tanımlar.
        /// GTFS tipi: ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("timeframe_group_id", PrimaryKey: true)]
        public string TimeframeGroupId { get; set; } = string.Empty;

        /// <summary>
        /// Zaman diliminin başlangıcını belirten yerel saat. Aralık bu değeri içerir.
        /// Koşul: end_time tanımlıysa zorunlu, boşsa yasaktır.
        /// GTFS tipi: Local time.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("start_time", PrimaryKey: true)]
        public string? StartTime { get; set; }

        /// <summary>
        /// Zaman diliminin sonunu belirten yerel saat. Aralık bu değeri içermez.
        /// Koşul: start_time tanımlıysa zorunlu, boşsa yasaktır.
        /// GTFS tipi: Local time.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("end_time", PrimaryKey: true)]
        public string? EndTime { get; set; }

        /// <summary>
        /// Zaman diliminin geçerli olduğu tarih kümesini tanımlar.
        /// GTFS tipi: Foreign ID referencing `calendar.service_id` or `calendar_dates.service_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("service_id", PrimaryKey: true, ForeignKey: true)]
        public string ServiceId { get; set; } = string.Empty;
    }
}
