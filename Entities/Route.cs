// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Toplu taşıma hatlarını tanımlar. Hat, yolculara tek bir hizmet olarak gösterilen seferler grubudur.
    /// Birincil anahtar: route_id
    /// </summary>
    [Presence(PresenceType.Required)]
    [GtfsFileName("routes")]
    public class Route : AGtfsEntity
    {
        /// <summary>
        /// Bir hattı tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("route_id", PrimaryKey: true, UniqueKey: true)]
        public string RouteId { get; set; } = string.Empty;

        /// <summary>
        /// Hattın ait olduğu kurum.
        /// Koşul: agency.txt içinde birden fazla kurum tanımlıysa zorunlu, aksi halde önerilir.
        /// GTFS tipi: Foreign ID referencing `agency.agency_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("agency_id", ForeignKey: true)]
        public string? AgencyId { get; set; }

        /// <summary>
        /// Hattın kısa adı (ör. "32", "100X", "Green").
        /// Koşul: route_long_name boşsa zorunludur.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("route_short_name")]
        public string? RouteShortName { get; set; }

        /// <summary>
        /// Hattın tam adı; genellikle varış noktasını veya durakları içerir.
        /// Koşul: route_short_name boşsa zorunludur.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("route_long_name")]
        public string? RouteLongName { get; set; }

        /// <summary>
        /// Hat hakkında faydalı ve nitelikli bilgi sağlayan açıklama.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("route_desc")]
        public string? RouteDesc { get; set; }

        /// <summary>
        /// Hatta kullanılan taşıma türünü belirtir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("route_type")]
        public RouteType RouteType { get; set; }

        /// <summary>
        /// Hat hakkındaki web sayfasının adresi.
        /// GTFS tipi: URL.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("route_url")]
        public string? RouteUrl { get; set; }

        /// <summary>
        /// Hattın renk kodu (onaltılık, # olmadan). Boş bırakılırsa beyaz (FFFFFF) kabul edilir.
        /// GTFS tipi: Color.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("route_color")]
        [DefaultValue("FFFFFF")]
        public string RouteColor { get; set; } = "FFFFFF";

        /// <summary>
        /// route_color arka planı üzerine yazılacak metnin rengi. Boş bırakılırsa siyah (000000) kabul edilir.
        /// GTFS tipi: Color.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("route_text_color")]
        [DefaultValue("000000")]
        public string RouteTextColor { get; set; } = "000000";

        /// <summary>
        /// Hatların yolculara gösterim sırası. Küçük değerler önce gösterilmelidir.
        /// GTFS tipi: Non-negative integer.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("route_sort_order")]
        public int? RouteSortOrder { get; set; }

        /// <summary>
        /// Yolcunun, aracın güzergahı boyunca herhangi bir noktada binip binemeyeceğini belirtir. Boş bırakılırsa 1 (sürekli alma yok) kabul edilir.
        /// Koşul: stop_times içinde pickup/drop-off penceresi tanımlıysa 1 dışındaki değerler yasaktır.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("continuous_pickup")]
        [DefaultValue(ContinuousPickupDropOff.NotContinuous)]
        public ContinuousPickupDropOff ContinuousPickup { get; set; } = ContinuousPickupDropOff.NotContinuous;

        /// <summary>
        /// Yolcunun, aracın güzergahı boyunca herhangi bir noktada inip inemeyeceğini belirtir. Boş bırakılırsa 1 (sürekli indirme yok) kabul edilir.
        /// Koşul: stop_times içinde pickup/drop-off penceresi tanımlıysa 1 dışındaki değerler yasaktır.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("continuous_drop_off")]
        [DefaultValue(ContinuousPickupDropOff.NotContinuous)]
        public ContinuousPickupDropOff ContinuousDropOff { get; set; } = ContinuousPickupDropOff.NotContinuous;

        /// <summary>
        /// Bir hat grubunu (ağı) tanımlar.
        /// Koşul: route_networks.txt veya networks.txt dosyası varsa yasaktır.
        /// GTFS tipi: ID.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("network_id")]
        public string? NetworkId { get; set; }

        /// <summary>
        /// Bu hatta temassız EMV (cEMV) kart veya mobil cihazın ödeme aracı olarak kullanılıp kullanılamayacağını belirtir. agency.cemv_support değerine göre önceliklidir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("cemv_support")]
        [DefaultValue(CemvSupport.NoInformation)]
        public CemvSupport CemvSupport { get; set; } = CemvSupport.NoInformation;
    }
}
