// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// Başlangıç ve bitiş tarihleri olan haftalık bir çizelge ile hizmet tarihlerini tanımlar.
    /// Tüm hizmet tarihleri calendar_dates.txt içinde tanımlanmadıkça zorunludur.
    /// Birincil anahtar: service_id
    /// </summary>
    [Presence(PresenceType.ConditionallyRequired)]
    [GtfsFileName("calendar")]
    public class Calendar : AGtfsEntity
    {
        /// <summary>
        /// Bir veya daha fazla hat için hizmet tarihleri kümesini benzersiz olarak tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("service_id", PrimaryKey: true, UniqueKey: true)]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// Hizmetin tarih aralığındaki tüm pazartesi günleri çalışıp çalışmadığını belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("monday")]
        public ServiceAvailability Monday { get; set; }

        /// <summary>
        /// Hizmetin tarih aralığındaki tüm salı günleri çalışıp çalışmadığını belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("tuesday")]
        public ServiceAvailability Tuesday { get; set; }

        /// <summary>
        /// Hizmetin tarih aralığındaki tüm çarşamba günleri çalışıp çalışmadığını belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("wednesday")]
        public ServiceAvailability Wednesday { get; set; }

        /// <summary>
        /// Hizmetin tarih aralığındaki tüm perşembe günleri çalışıp çalışmadığını belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("thursday")]
        public ServiceAvailability Thursday { get; set; }

        /// <summary>
        /// Hizmetin tarih aralığındaki tüm cuma günleri çalışıp çalışmadığını belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("friday")]
        public ServiceAvailability Friday { get; set; }

        /// <summary>
        /// Hizmetin tarih aralığındaki tüm cumartesi günleri çalışıp çalışmadığını belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("saturday")]
        public ServiceAvailability Saturday { get; set; }

        /// <summary>
        /// Hizmetin tarih aralığındaki tüm pazar günleri çalışıp çalışmadığını belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("sunday")]
        public ServiceAvailability Sunday { get; set; }

        /// <summary>
        /// Hizmet aralığının başlangıç günü (YYYYMMDD).
        /// GTFS tipi: Date.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("start_date")]
        public string StartDate { get; set; } = string.Empty;

        /// <summary>
        /// Hizmet aralığının bitiş günü (YYYYMMDD); bu gün aralığa dahildir.
        /// GTFS tipi: Date.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("end_date")]
        public string EndDate { get; set; } = string.Empty;
    }
}
