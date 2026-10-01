// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Yolcu talebine bağlı hizmetler için rezervasyon bilgilerini tanımlar.
    /// Birincil anahtar: booking_rule_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("booking_rules")]
    public class BookingRule : AGtfsEntity
    {
        /// <summary>
        /// Bir rezervasyon kuralını tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("booking_rule_id", PrimaryKey: true, UniqueKey: true)]
        public string BookingRuleId { get; set; } = string.Empty;

        /// <summary>
        /// Rezervasyonun ne kadar önceden yapılabileceğini belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("booking_type")]
        public BookingType BookingType { get; set; }

        /// <summary>
        /// Hizmetten önce rezervasyon yapılması gereken minimum süre (dakika).
        /// Koşul: booking_type=1 ise zorunlu, aksi halde yasaktır.
        /// GTFS tipi: Integer.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("prior_notice_duration_min")]
        public int? PriorNoticeDurationMin { get; set; }

        /// <summary>
        /// Hizmetten en fazla ne kadar önce rezervasyon yapılabileceği (dakika).
        /// Koşul: booking_type 0 veya 2 ise yasak; 1 ise isteğe bağlıdır.
        /// GTFS tipi: Integer.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("prior_notice_duration_max")]
        public int? PriorNoticeDurationMax { get; set; }

        /// <summary>
        /// Hizmetten önceki son rezervasyon günü (ör. "1" bir gün önce demektir).
        /// Koşul: booking_type=2 ise zorunlu, aksi halde yasaktır.
        /// GTFS tipi: Integer.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("prior_notice_last_day")]
        public int? PriorNoticeLastDay { get; set; }

        /// <summary>
        /// Hizmetten önceki son gün içindeki son rezervasyon saati.
        /// Koşul: prior_notice_last_day tanımlıysa zorunlu, aksi halde yasaktır.
        /// GTFS tipi: Time.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("prior_notice_last_time")]
        public string? PriorNoticeLastTime { get; set; }

        /// <summary>
        /// Hizmetten önce rezervasyonun yapılabileceği en erken gün.
        /// Koşul: booking_type=0 ise veya booking_type=1 ve prior_notice_duration_max tanımlıysa yasak; aksi halde isteğe bağlıdır.
        /// GTFS tipi: Integer.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("prior_notice_start_day")]
        public int? PriorNoticeStartDay { get; set; }

        /// <summary>
        /// Hizmetten önceki en erken rezervasyon gününde rezervasyonun başlayabileceği saat.
        /// Koşul: prior_notice_start_day tanımlıysa zorunlu, aksi halde yasaktır.
        /// GTFS tipi: Time.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("prior_notice_start_time")]
        public string? PriorNoticeStartTime { get; set; }

        /// <summary>
        /// prior_notice_last_day ve prior_notice_start_day değerlerinin sayıldığı hizmet günlerini belirtir.
        /// Koşul: booking_type=2 ise isteğe bağlı, aksi halde yasaktır.
        /// GTFS tipi: Foreign ID referencing `calendar.service_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("prior_notice_service_id", ForeignKey: true)]
        public string? PriorNoticeServiceId { get; set; }

        /// <summary>
        /// Talebe bağlı bir duraktan binen veya inen yolcuya gösterilen mesaj.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// message alanıyla aynı işleve sahiptir, ancak yalnızca biniş için kullanılır.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("pickup_message")]
        public string? PickupMessage { get; set; }

        /// <summary>
        /// message alanıyla aynı işleve sahiptir, ancak yalnızca iniş için kullanılır.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("drop_off_message")]
        public string? DropOffMessage { get; set; }

        /// <summary>
        /// Rezervasyon için aranacak telefon numarası.
        /// GTFS tipi: Phone number.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("phone_number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Rezervasyon kuralı hakkında bilgi veren web adresi.
        /// GTFS tipi: URL.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("info_url")]
        public string? InfoUrl { get; set; }

        /// <summary>
        /// Rezervasyonun yapılabileceği çevrim içi arayüz veya uygulamanın adresi.
        /// GTFS tipi: URL.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("booking_url")]
        public string? BookingUrl { get; set; }
    }
}
