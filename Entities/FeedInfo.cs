// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Bu dosya, veri kümesinin açıkladığı hizmetler yerine veri kümesinin kendisiyle ilgili bilgileri (yayıncı, sürüm, geçerlilik süresi) içerir.
    /// Bazı durumlarda, veri kümesinin yayıncısı ajanslardan farklıdır. translations.txt sağlanmışsa bu dosya gereklidir, aksi halde önerilir.
    /// Birincil anahtar: yok (dosya yalnızca tek satır içerebilir)
    /// </summary>
    [Presence(PresenceType.ConditionallyRequired)]
    [GtfsFileName("feed_info")]
    public class FeedInfo : AGtfsEntity
    {
        /// <summary>
        /// Veri kümesini yayınlayan kuruluşun tam adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("feed_publisher_name")]
        public string FeedPublisherName { get; set; } = string.Empty;

        /// <summary>
        /// Veri kümesini yayınlayan kuruluşun web adresi.
        /// GTFS tipi: URL.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("feed_publisher_url")]
        public string FeedPublisherUrl { get; set; } = string.Empty;

        /// <summary>
        /// Veri kümesindeki metinler için kullanılan varsayılan dil. Birden fazla dil varsa "mul" kullanılabilir.
        /// GTFS tipi: Language code.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("feed_lang")]
        public string FeedLang { get; set; } = string.Empty;

        /// <summary>
        /// Yolcunun dili bilinmediğinde kullanılacak dili tanımlar.
        /// GTFS tipi: Language code.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("default_lang")]
        public string? DefaultLang { get; set; }

        /// <summary>
        /// Veri kümesinin hizmet bilgisi sağladığı dönemin başlangıç tarihi (YYYYMMDD).
        /// GTFS tipi: Date.
        /// </summary>
        [Presence(PresenceType.Recommended)]
        [GtfsFieldName("feed_start_date")]
        public string? FeedStartDate { get; set; }

        /// <summary>
        /// Veri kümesinin hizmet bilgisi sağladığı dönemin bitiş tarihi (YYYYMMDD).
        /// GTFS tipi: Date.
        /// </summary>
        [Presence(PresenceType.Recommended)]
        [GtfsFieldName("feed_end_date")]
        public string? FeedEndDate { get; set; }

        /// <summary>
        /// Veri kümesinin mevcut sürümünü belirten metin.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Recommended)]
        [GtfsFieldName("feed_version")]
        public string? FeedVersion { get; set; }

        /// <summary>
        /// Veri kümesi ile ilgili teknik iletişim için e-posta adresi.
        /// GTFS tipi: Email.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("feed_contact_email")]
        public string? FeedContactEmail { get; set; }

        /// <summary>
        /// Veri kümesi ile ilgili teknik iletişim için web adresi.
        /// GTFS tipi: URL.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("feed_contact_url")]
        public string? FeedContactUrl { get; set; }
    }
}
