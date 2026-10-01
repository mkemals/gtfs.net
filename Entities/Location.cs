// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.
#nullable enable

using System;
using System.ComponentModel;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Talebe bağlı (on-demand) hizmetlerde yolcunun alınma veya indirilme talep edebileceği, GeoJSON poligonlarıyla gösterilen bölgeleri tanımlar.
    /// Dosya bir GeoJSON FeatureCollection içerir; bu sınıf koleksiyondaki tek bir Feature nesnesini temsil eder.
    /// </summary>
    [Presence(PresenceType.Optional)]
    [GtfsFileName("locations", Extension = ".geojson")]
    public class Location : AGtfsEntity
    {
        /// <summary>
        /// GeoJSON nesne türü. Her zaman "Feature" olmalıdır.
        /// GTFS tipi: String.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Konumu tanımlar. stops.stop_id, locations.geojson id ve location_groups.location_group_id değerleri arasında benzersiz olmalıdır.
        /// GTFS tipi: String.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("id", UniqueKey: true)]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Konumun yolculara gösterilen adı (properties.stop_name).
        /// GTFS tipi: String.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("properties.stop_name")]
        public string? StopName { get; set; }

        /// <summary>
        /// Yolcuların yönünü bulmasına yardımcı olacak anlamlı açıklama (properties.stop_desc).
        /// GTFS tipi: String.
        /// </summary>
        [Presence(PresenceType.Optional)]
        [GtfsFieldName("properties.stop_desc")]
        public string? StopDesc { get; set; }

        /// <summary>
        /// Konum geometrisinin türü: "Polygon" veya "MultiPolygon" (geometry.type).
        /// GTFS tipi: String.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("geometry.type")]
        public string GeometryType { get; set; } = string.Empty;

        /// <summary>
        /// Konum geometrisini tanımlayan coğrafi koordinatlar (geometry.coordinates). Her konum [boylam, enlem] çiftidir.
        /// Polygon geometrisi tek poligonlu bir MultiPolygon olarak saklanır: [poligon][halka][nokta][boylam, enlem].
        /// GTFS tipi: Array.
        /// </summary>
        [Presence(PresenceType.Required)]
        [GtfsFieldName("geometry.coordinates")]
        public double[][][][] Coordinates { get; set; } = Array.Empty<double[][][]>();
    }
}
