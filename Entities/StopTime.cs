// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Her sefer için bir aracın duraklara varış ve duraklardan kalkış zamanlarını tanımlar.
    /// Birincil anahtar: trip_id, stop_sequence
    /// </summary>
    [Presence(PresenceType.Required)]
    [GtfsFileName("stop_times")]
    public class StopTime : AGtfsEntity
    {
        /// <summary>
        /// Seferi tanımlar.
        /// GTFS tipi: Foreign ID referencing `trips.trip_id`.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("trip_id", PrimaryKey: true, ForeignKey: true)]
        public string TripId { get; set; } = string.Empty;

        /// <summary>
        /// Varış zamanı (HH:MM:SS, 24:00:00 üzerinde olabilir).
        /// Koşul: Seferin ilk ve son durağı için ve timepoint=1 için zorunlu; pickup/drop-off penceresi tanımlıysa yasaktır.
        /// GTFS tipi: Time.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("arrival_time")]
        public string? ArrivalTime { get; set; }

        /// <summary>
        /// Kalkış zamanı (HH:MM:SS, 24:00:00 üzerinde olabilir).
        /// Koşul: timepoint=1 için zorunlu; pickup/drop-off penceresi tanımlıysa yasaktır.
        /// GTFS tipi: Time.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("departure_time")]
        public string? DepartureTime { get; set; }

        /// <summary>
        /// Hizmet verilen durağı tanımlar.
        /// Koşul: location_group_id veya location_id tanımlı değilse zorunlu; tanımlıysa yasaktır.
        /// GTFS tipi: Foreign ID referencing `stops.stop_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("stop_id", ForeignKey: true)]
        public string? StopId { get; set; }

        /// <summary>
        /// Yolcunun binme/inme talep edebileceği konum grubunu tanımlar.
        /// Koşul: stop_id veya location_id tanımlıysa yasaktır.
        /// GTFS tipi: Foreign ID referencing `location_groups.location_group_id`.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("location_group_id", ForeignKey: true)]
        public string? LocationGroupId { get; set; }

        /// <summary>
        /// locations.geojson içindeki talebe bağlı bölgeyi tanımlar.
        /// Koşul: stop_id veya location_group_id tanımlıysa yasaktır.
        /// GTFS tipi: Foreign ID referencing `id` from `locations.geojson`.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("location_id", ForeignKey: true)]
        public string? LocationId { get; set; }

        /// <summary>
        /// Bir seferdeki durakların, konumların ve konum gruplarının sırası. Sefer boyunca artmalıdır.
        /// GTFS tipi: Non-negative integer.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("stop_sequence", PrimaryKey: true)]
        public int StopSequence { get; set; }

        /// <summary>
        /// Duraktan itibaren geçerli olan tabela metni; trips.trip_headsign değerini geçersiz kılar.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("stop_headsign")]
        public string? StopHeadsign { get; set; }

        /// <summary>
        /// Talebe bağlı hizmetin başladığı zaman.
        /// Koşul: location_group_id veya location_id tanımlıysa zorunlu; arrival_time/departure_time tanımlıysa yasaktır.
        /// GTFS tipi: Time.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("start_pickup_drop_off_window")]
        public string? StartPickupDropOffWindow { get; set; }

        /// <summary>
        /// Talebe bağlı hizmetin sona erdiği zaman.
        /// Koşul: location_group_id veya location_id tanımlıysa zorunlu; arrival_time/departure_time tanımlıysa yasaktır.
        /// GTFS tipi: Time.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("end_pickup_drop_off_window")]
        public string? EndPickupDropOffWindow { get; set; }

        /// <summary>
        /// Yolcu alma yöntemini belirtir. Boş bırakılırsa 0 (düzenli alma) kabul edilir.
        /// Koşul: pickup/drop-off penceresi tanımlıysa 0 ve 3 değerleri yasaktır.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("pickup_type")]
        [DefaultValue(PickupDropOffType.Regular)]
        public PickupDropOffType PickupType { get; set; } = PickupDropOffType.Regular;

        /// <summary>
        /// Yolcu indirme yöntemini belirtir. Boş bırakılırsa 0 (düzenli indirme) kabul edilir.
        /// Koşul: pickup/drop-off penceresi tanımlıysa 0 değeri yasaktır.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("drop_off_type")]
        [DefaultValue(PickupDropOffType.Regular)]
        public PickupDropOffType DropOffType { get; set; } = PickupDropOffType.Regular;

        /// <summary>
        /// Bu duraktan bir sonrakine kadar güzergah boyunca sürekli yolcu alma yapılıp yapılmadığını belirtir. Boş bırakılırsa 1 kabul edilir; routes.continuous_pickup değerini geçersiz kılar.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("continuous_pickup")]
        [DefaultValue(ContinuousPickupDropOff.NotContinuous)]
        public ContinuousPickupDropOff ContinuousPickup { get; set; } = ContinuousPickupDropOff.NotContinuous;

        /// <summary>
        /// Bu duraktan bir sonrakine kadar güzergah boyunca sürekli yolcu indirme yapılıp yapılmadığını belirtir. Boş bırakılırsa 1 kabul edilir; routes.continuous_drop_off değerini geçersiz kılar.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.ConditionallyForbidden)]
        [GtfsFieldName("continuous_drop_off")]
        [DefaultValue(ContinuousPickupDropOff.NotContinuous)]
        public ContinuousPickupDropOff ContinuousDropOff { get; set; } = ContinuousPickupDropOff.NotContinuous;

        /// <summary>
        /// İlk duraktan bu kayda kadar şekil (shape) boyunca kat edilen gerçek mesafe.
        /// GTFS tipi: Non-negative float.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("shape_dist_traveled")]
        public double? ShapeDistTraveled { get; set; }

        /// <summary>
        /// Varış ve kalkış zamanlarının kesin mi yoksa yaklaşık/enterpolasyonlu mu olduğunu belirtir. Hiç değer verilmezse tüm zamanlar kesin kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("timepoint")]
        [DefaultValue(TimepointType.Exact)]
        public TimepointType Timepoint { get; set; } = TimepointType.Exact;

        /// <summary>
        /// Bu durak için yolcu alma rezervasyon kuralını tanımlar.
        /// GTFS tipi: Foreign ID referencing `booking_rules.booking_rule_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("pickup_booking_rule_id", ForeignKey: true)]
        public string? PickupBookingRuleId { get; set; }

        /// <summary>
        /// Bu durak için yolcu indirme rezervasyon kuralını tanımlar.
        /// GTFS tipi: Foreign ID referencing `booking_rules.booking_rule_id`.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("drop_off_booking_rule_id", ForeignKey: true)]
        public string? DropOffBookingRuleId { get; set; }
    }
}
