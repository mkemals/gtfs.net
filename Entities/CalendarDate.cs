// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// calendar.txt içinde tanımlanan hizmetler için istisnaları tanımlar.
    /// calendar.txt yoksa zorunludur; bu durumda calendar_dates.txt tüm hizmet tarihlerini içermelidir.
    /// Birincil anahtar: service_id, date
    /// </summary>
    [Presence(PresenceType.ConditionallyRequired)]
    [GtfsFileName("calendar_dates")]
    public class CalendarDate : AGtfsEntity
    {
        /// <summary>
        /// Hizmetin eklendiği veya kaldırıldığı tarihlerin hizmet kimliği.
        /// GTFS tipi: Foreign ID referencing `calendar.service_id` or ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("service_id", PrimaryKey: true, ForeignKey: true)]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// Hizmet istisnasının uygulandığı tarih (YYYYMMDD).
        /// GTFS tipi: Date.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("date", PrimaryKey: true)]
        public string Date { get; set; } = string.Empty;

        /// <summary>
        /// Belirtilen tarihte hizmetin eklenip eklenmediğini veya kaldırılıp kaldırılmadığını belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("exception_type")]
        public ExceptionType ExceptionType { get; set; }
    }
}
