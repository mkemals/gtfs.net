// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

using System;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Sınıfın karşılık geldiği GTFS dosyasının adını (uzantısız) belirtir. Örn: "feed_info" → feed_info.txt
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class GtfsFileNameAttribute : Attribute
    {
        public GtfsFileNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>Uzantısız dosya adı.</summary>
        public string Name { get; }

        /// <summary>Dosya uzantısı. Varsayılan: ".txt"</summary>
        public string Extension { get; set; } = ".txt";

        /// <summary>Uzantılı tam dosya adı. Örn: "feed_info.txt"</summary>
        public string FullName => Name + Extension;
    }
}
