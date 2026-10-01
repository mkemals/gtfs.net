// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Bu veri kümesinde hizmetleri temsil edilen toplu taşıma kurumlarını (ajansları) tanımlar.
    /// Birincil anahtar: agency_id
    /// </summary>
    [Presence(PresenceType.Required)]
    [GtfsFileName("agency")]
    public class Agency : AGtfsEntity
    {
        /// <summary>
        /// Genellikle bir ulaşım kurumuyla eş anlamlı olan ulaşım markasını tanımlar.
        /// Koşul: Veri kümesi birden fazla kuruma ait veri içeriyorsa zorunlu, aksi halde önerilir.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("agency_id", PrimaryKey: true, UniqueKey: true)]
        public string? AgencyId { get; set; }

        /// <summary>
        /// Ulaşım kurumunun tam adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("agency_name")]
        public string AgencyName { get; set; } = string.Empty;

        /// <summary>
        /// Ulaşım kurumunun web adresi (URL).
        /// GTFS tipi: URL.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("agency_url")]
        public string AgencyUrl { get; set; } = string.Empty;

        /// <summary>
        /// Ulaşım kurumunun bulunduğu saat dilimi. Birden fazla kurum varsa hepsinin agency_timezone değeri aynı olmalıdır.
        /// GTFS tipi: Timezone.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("agency_timezone")]
        public string AgencyTimezone { get; set; } = string.Empty;

        /// <summary>
        /// Kurumun kullandığı birincil dil.
        /// GTFS tipi: Language code.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("agency_lang")]
        public string? AgencyLang { get; set; }

        /// <summary>
        /// Kurumun sesli iletişim telefon numarası.
        /// GTFS tipi: Phone number.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("agency_phone")]
        public string? AgencyPhone { get; set; }

        /// <summary>
        /// Yolcunun bilet satın alabileceği veya kurumun ücretleri hakkında bilgi alabileceği web sayfasının adresi.
        /// GTFS tipi: URL.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("agency_fare_url")]
        public string? AgencyFareUrl { get; set; }

        /// <summary>
        /// Kurumun müşteri hizmetleri tarafından aktif olarak takip edilen e-posta adresi.
        /// GTFS tipi: Email.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("agency_email")]
        public string? AgencyEmail { get; set; }

        /// <summary>
        /// Bu kuruma ait seferlerde temassız EMV (cEMV) kart veya mobil cihazın ödeme aracı olarak kullanılıp kullanılamayacağını belirtir. routes.cemv_support tanımlıysa o öncelik kazanır.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("cemv_support")]
        [DefaultValue(CemvSupport.NoInformation)]
        public CemvSupport CemvSupport { get; set; } = CemvSupport.NoInformation;
    }
}
