// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Ücret ürünlerini kullanmak için kullanılabilecek ödeme araçlarını (bilet, kart, mobil uygulama vb.) tanımlar.
    /// Bu dosya, fare_attributes.txt ve fare_rules.txt dosyalarından tamamen bağımsızdır.
    /// Birincil anahtar: fare_media_id
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("fare_media")]
    public class FareMedia : AGtfsEntity
    {
        /// <summary>
        /// Bir ödeme aracını tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("fare_media_id", PrimaryKey: true, UniqueKey: true)]
        public string FareMediaId { get; set; } = string.Empty;

        /// <summary>
        /// Ödeme aracının adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("fare_media_name")]
        public string? FareMediaName { get; set; }

        /// <summary>
        /// Ödeme aracının türü.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("fare_media_type")]
        public FareMediaType FareMediaType { get; set; }
    }
}
