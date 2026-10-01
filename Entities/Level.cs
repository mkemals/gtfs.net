// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace GtfsNet
{
    /// <summary>
    /// İstasyonlar içindeki katları (seviyeleri) tanımlar.
    /// Asansör içeren geçitler (pathway_mode=5) tanımlanıyorsa zorunludur, aksi halde isteğe bağlıdır.
    /// Birincil anahtar: level_id
    /// </summary>
    [Presence(PresenceType.ConditionallyRequired)]
    [GtfsFileName("levels")]
    public class Level : AGtfsEntity
    {
        /// <summary>
        /// İstasyondaki bir katı tanımlar.
        /// GTFS tipi: Unique ID.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("level_id", PrimaryKey: true, UniqueKey: true)]
        public string LevelId { get; set; } = string.Empty;

        /// <summary>
        /// Katın diğer katlara göre göreli konumunu belirten sayısal indeks. Zemin kat 0, üst katlar pozitif, alt katlar negatif değerlerle gösterilir.
        /// GTFS tipi: Float.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("level_index")]
        public double LevelIndex { get; set; }

        /// <summary>
        /// Katın yolculara gösterilen adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("level_name")]
        public string? LevelName { get; set; }
    }
}
