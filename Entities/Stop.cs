// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Araçların yolcu aldığı veya indirdiği durakları tanımlar. İstasyonlar ve istasyon girişleri de bu dosyada tanımlanır.
    /// locations.geojson içinde talebe bağlı bölgeler tanımlanmışsa isteğe bağlıdır, aksi halde zorunludur.
    /// Birincil anahtar: stop_id
    /// </summary>
    [Presence(PresenceType.ConditionallyRequired)]
    [GtfsFileName("stops")]
    public class Stop : AGtfsEntity
    {
        /// <summary>
        /// Bir konumu tanımlar: durak/peron, istasyon, giriş/çıkış, genel düğüm veya biniş alanı. stops.stop_id, locations.geojson id ve location_groups.location_group_id değerleri arasında benzersiz olmalıdır.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("stop_id", PrimaryKey: true, UniqueKey: true)]
        public string StopId { get; set; } = string.Empty;

        /// <summary>
        /// Konumu yolcular için tanımlayan kısa metin veya numara.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("stop_code")]
        public string? StopCode { get; set; }

        /// <summary>
        /// Konumun adı.
        /// Koşul: Duraklar (location_type=0), istasyonlar (1) ve giriş/çıkışlar (2) için zorunlu; genel düğümler (3) ve biniş alanları (4) için isteğe bağlıdır.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("stop_name")]
        public string? StopName { get; set; }

        /// <summary>
        /// stop_name alanının metinden konuşmaya (text-to-speech) uygun okunabilir sürümü.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("tts_stop_name")]
        public string? TtsStopName { get; set; }

        /// <summary>
        /// Konumla ilgili faydalı ve nitelikli bilgi sağlayan açıklama. stop_name ile aynı olmamalıdır.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("stop_desc")]
        public string? StopDesc { get; set; }

        /// <summary>
        /// Konumun enlemi (WGS84).
        /// Koşul: location_type 0, 1 veya 2 ise zorunlu; 3 veya 4 ise isteğe bağlıdır.
        /// GTFS tipi: Latitude.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("stop_lat")]
        public double? StopLat { get; set; }

        /// <summary>
        /// Konumun boylamı (WGS84).
        /// Koşul: location_type 0, 1 veya 2 ise zorunlu; 3 veya 4 ise isteğe bağlıdır.
        /// GTFS tipi: Longitude.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("stop_lon")]
        public double? StopLon { get; set; }

        /// <summary>
        /// Durağın ücret bölgesini tanımlar. Kayıt bir istasyon veya istasyon girişiyse dikkate alınmaz.
        /// GTFS tipi: ID.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("zone_id")]
        public string? ZoneId { get; set; }

        /// <summary>
        /// Konum hakkındaki web sayfasının adresi.
        /// GTFS tipi: URL.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("stop_url")]
        public string? StopUrl { get; set; }

        /// <summary>
        /// Konum türü. Boş bırakılırsa 0 (Durak/Peron) kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("location_type")]
        [DefaultValue(LocationType.StopOrPlatform)]
        public LocationType LocationType { get; set; } = LocationType.StopOrPlatform;

        /// <summary>
        /// Konumlar arasındaki hiyerarşiyi tanımlar; üst konumun kimliğini içerir.
        /// Koşul: Girişler (2), genel düğümler (3) ve biniş alanları (4) için zorunlu; duraklar (0) için isteğe bağlı; istasyonlar (1) için yasaktır.
        /// GTFS tipi: Foreign ID referencing `stops.stop_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("parent_station", ForeignKey: true)]
        public string? ParentStation { get; set; }

        /// <summary>
        /// Konumun saat dilimi. Üst istasyonu olan konumlar üst istasyonun saat dilimini devralır.
        /// GTFS tipi: Timezone.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("stop_timezone")]
        public string? StopTimezone { get; set; }

        /// <summary>
        /// Konumdan tekerlekli sandalyeyle binişin mümkün olup olmadığını belirtir. Boş bırakılırsa 0 kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("wheelchair_boarding")]
        [DefaultValue(WheelchairBoarding.NoInformation)]
        public WheelchairBoarding WheelchairBoarding { get; set; } = WheelchairBoarding.NoInformation;

        /// <summary>
        /// Konumun bulunduğu kat (seviye).
        /// GTFS tipi: Foreign ID referencing `levels.level_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("level_id", ForeignKey: true)]
        public string? LevelId { get; set; }

        /// <summary>
        /// İstasyona ait bir peron durağı için peron tanımlayıcısı (ör. "G" veya "3").
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("platform_code")]
        public string? PlatformCode { get; set; }

        /// <summary>
        /// Durağa belirli bir istasyon için nasıl erişildiğini belirtir. Boşsa erişim tanımsız kabul edilir.
        /// Koşul: İstasyonlar, girişler, genel düğümler ve biniş alanları için ve parent_station boşsa yasaktır; aksi halde isteğe bağlıdır.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("stop_access")]
        public StopAccess? StopAccess { get; set; }
    }
}
