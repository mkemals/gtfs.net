// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Yolcuya gösterilen veri kümesi değerlerinin çevirilerini tanımlar.
    /// Birincil anahtar: table_name, field_name, language, record_id, record_sub_id, field_value
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("translations")]
    public class Translation : AGtfsEntity
    {
        /// <summary>
        /// Çevrilecek alanı içeren tabloyu (dosya adını, .txt uzantısı olmadan) tanımlar. İzin verilen değerler: agency, stops, routes, trips, stop_times, pathways, levels, feed_info, attributions.
        /// GTFS tipi: Enum.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("table_name", PrimaryKey: true)]
        public string TableName { get; set; } = string.Empty;

        /// <summary>
        /// Çevrilecek alanın adı.
        /// GTFS tipi: Text.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("field_name", PrimaryKey: true)]
        public string FieldName { get; set; } = string.Empty;

        /// <summary>
        /// Çevirinin dil kodu.
        /// GTFS tipi: Language code.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("language", PrimaryKey: true)]
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// Çevrilmiş değer.
        /// GTFS tipi: Text or URL or Email or Phone number.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("translation")]
        public string TranslatedValue { get; set; } = string.Empty;

        /// <summary>
        /// Çevrilecek alanı içeren kaydı tanımlar.
        /// Koşul: table_name=feed_info ise veya field_value tanımlıysa yasak; aksi halde zorunludur.
        /// GTFS tipi: Foreign ID.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("record_id", PrimaryKey: true, ForeignKey: true)]
        public string? RecordId { get; set; }

        /// <summary>
        /// Benzersiz kimliği olmayan tablolardaki kaydı tanımlamaya yardımcı olur (ör. stop_times için stop_sequence).
        /// Koşul: table_name=stop_times ve record_id tanımlıysa zorunludur.
        /// GTFS tipi: Foreign ID.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("record_sub_id", PrimaryKey: true, ForeignKey: true)]
        public string? RecordSubId { get; set; }

        /// <summary>
        /// record_id yerine, çevirinin uygulanacağı alan değerini doğrudan belirtir.
        /// Koşul: record_id tanımlıysa veya table_name=feed_info ise yasak; record_id boşsa zorunludur.
        /// GTFS tipi: Text or URL or Email or Phone number.
        /// </summary>
        [Presence(PresenceType.ConditionallyRequired)]
        [GtfsFieldName("field_value", PrimaryKey: true)]
        public string? FieldValue { get; set; }
    }
}
