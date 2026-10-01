// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// Her hat için seferleri tanımlar. Sefer, belirli bir zaman diliminde gerçekleşen iki veya daha fazla duraktan oluşan bir dizidir.
    /// Birincil anahtar: trip_id
    /// </summary>
    [Presence(PresenceType.Required)]
    [GtfsFileName("trips")]
    public class Trip : AGtfsEntity
    {
        /// <summary>
        /// Seferin ait olduğu hattı tanımlar.
        /// GTFS tipi: Foreign ID referencing `routes.route_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("route_id", ForeignKey: true)]
        public string RouteId { get; set; } = string.Empty;

        /// <summary>
        /// Seferin hizmet verdiği tarih kümesini tanımlar.
        /// GTFS tipi: Foreign ID referencing `calendar.service_id` or `calendar_dates.service_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("service_id", ForeignKey: true)]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// Bir seferi tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("trip_id", PrimaryKey: true, UniqueKey: true)]
        public string TripId { get; set; } = string.Empty;

        /// <summary>
        /// Seferin varış noktasını yolculara gösteren tabela metni.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("trip_headsign")]
        public string? TripHeadsign { get; set; }

        /// <summary>
        /// Yolculara seferi tanıtan, yolcuya açık metin (ör. tren numarası).
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("trip_short_name")]
        public string? TripShortName { get; set; }

        /// <summary>
        /// Seferin yönünü belirtir. Güzergah hesaplamasında kullanılmamalıdır; tarifelerde yönleri ayırmak içindir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("direction_id")]
        public DirectionType? DirectionId { get; set; }

        /// <summary>
        /// Seferin ait olduğu bloğu tanımlar. Blok, aynı aracın kullandığı ardışık seferlerden oluşur.
        /// GTFS tipi: ID.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("block_id")]
        public string? BlockId { get; set; }

        /// <summary>
        /// Sefer için aracın izlediği güzergah geometrisini tanımlar.
        /// Koşul: Hat veya durak saatlerinde sürekli alma/indirme tanımlıysa zorunlu, aksi halde isteğe bağlıdır.
        /// GTFS tipi: Foreign ID referencing `shapes.shape_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("shape_id", ForeignKey: true)]
        public string? ShapeId { get; set; }

        /// <summary>
        /// Tekerlekli sandalye erişilebilirliğini belirtir. Boş bırakılırsa 0 kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("wheelchair_accessible")]
        [DefaultValue(WheelchairAccessibility.NoInformation)]
        public WheelchairAccessibility WheelchairAccessible { get; set; } = WheelchairAccessibility.NoInformation;

        /// <summary>
        /// Bisiklete izin verilip verilmediğini belirtir. Boş bırakılırsa 0 kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("bikes_allowed")]
        [DefaultValue(BikesAllowance.NoInformation)]
        public BikesAllowance BikesAllowed { get; set; } = BikesAllowance.NoInformation;

        /// <summary>
        /// Otomobile izin verilip verilmediğini belirtir. Boş bırakılırsa 0 kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("cars_allowed")]
        [DefaultValue(CarsAllowance.NoInformation)]
        public CarsAllowance CarsAllowed { get; set; } = CarsAllowance.NoInformation;

        /// <summary>
        /// Talebe bağlı yolculuklarda güvenli seyahat süresini hesaplamak için kullanılan çarpan.
        /// GTFS tipi: Float.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("safe_duration_factor")]
        public double? SafeDurationFactor { get; set; }

        /// <summary>
        /// Talebe bağlı yolculuklarda güvenli seyahat süresini hesaplamak için eklenen sabit ofset (saniye).
        /// GTFS tipi: Float.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("safe_duration_offset")]
        public double? SafeDurationOffset { get; set; }
    }
}
