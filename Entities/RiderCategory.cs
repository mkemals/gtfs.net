// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Yolcu kategorilerini (ör. yaşlı, öğrenci) tanımlar.
    /// Birincil anahtar: rider_category_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("rider_categories")]
    public class RiderCategory : AGtfsEntity
    {
        /// <summary>
        /// Bir yolcu kategorisini tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("rider_category_id", PrimaryKey: true, UniqueKey: true)]
        public string RiderCategoryId { get; set; } = string.Empty;

        /// <summary>
        /// Yolcu kategorisinin yolculara gösterilen adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("rider_category_name")]
        public string RiderCategoryName { get; set; } = string.Empty;

        /// <summary>
        /// Kategorinin varsayılan (yolculara gösterilecek ana) kategori olup olmadığını belirtir. Boş bırakılırsa 0 kabul edilir.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("is_default_fare_category")]
        [DefaultValue(DefaultFareCategory.NotDefault)]
        public DefaultFareCategory IsDefaultFareCategory { get; set; } = DefaultFareCategory.NotDefault;

        /// <summary>
        /// Yolcu kategorisinin uygunluk koşulları hakkında bilgi veren web sayfası.
        /// GTFS tipi: URL.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("eligibility_url")]
        public string? EligibilityUrl { get; set; }
    }
}
