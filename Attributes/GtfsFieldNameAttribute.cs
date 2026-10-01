// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

using System;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Property'nin karşılık geldiği GTFS alan (sütun) adını ve anahtar bilgilerini belirtir.
    /// Örn: [GtfsFieldName("stop_id", PrimaryKey: true, UniqueKey: true)]
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class GtfsFieldNameAttribute : Attribute
    {
        /// <param name="FieldName">GTFS alan adı. Örn: "feed_lang"</param>
        /// <param name="PrimaryKey">Alan, dosyanın birincil anahtarının (veya bileşik birincil anahtarın) parçasıdır.</param>
        /// <param name="ForeignKey">Alan, başka bir dosyadaki bir kimliğe başvurur (Foreign ID).</param>
        /// <param name="UniqueKey">Alan değeri dosya içinde benzersiz olmalıdır (Unique ID).</param>
        public GtfsFieldNameAttribute(string FieldName, bool PrimaryKey = false, bool ForeignKey = false, bool UniqueKey = false)
        {
            this.FieldName = FieldName;
            this.PrimaryKey = PrimaryKey;
            this.ForeignKey = ForeignKey;
            this.UniqueKey = UniqueKey;
        }

        /// <summary>GTFS alan adı.</summary>
        public string FieldName { get; }

        /// <summary>Alan, dosyanın birincil anahtarının (veya bileşik birincil anahtarın) parçasıdır.</summary>
        public bool PrimaryKey { get; }

        /// <summary>Alan, başka bir dosyadaki bir kimliğe başvurur (Foreign ID).</summary>
        public bool ForeignKey { get; }

        /// <summary>Alan değeri dosya içinde benzersiz olmalıdır (Unique ID).</summary>
        public bool UniqueKey { get; }
    }
}
