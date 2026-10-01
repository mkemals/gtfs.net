// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Hatta kullanılan taşıma türü. Genişletilmiş GTFS hat türleri (100-1702) int dönüşümüyle de taşınabilir.
    /// </summary>
    public enum RouteType
    {
        /// <summary>
        /// 0 - Tramvay, hafif raylı sistem. Şehir içi yüzey seviyesindeki raylı sistemler.
        /// </summary>
        Tram = 0,

        /// <summary>
        /// 1 - Metro. Şehir içi yer altı raylı sistemleri.
        /// </summary>
        Subway = 1,

        /// <summary>
        /// 2 - Tren. Şehirlerarası veya uzun mesafeli seyahat.
        /// </summary>
        Rail = 2,

        /// <summary>
        /// 3 - Otobüs. Kısa ve uzun mesafeli otobüs hatları.
        /// </summary>
        Bus = 3,

        /// <summary>
        /// 4 - Feribot / vapur. Kısa ve uzun mesafeli deniz taşımacılığı.
        /// </summary>
        Ferry = 4,

        /// <summary>
        /// 5 - Kablolu tramvay. Kablonun aracın altından geçtiği yüzey raylı araçları.
        /// </summary>
        CableTram = 5,

        /// <summary>
        /// 6 - Teleferik, gondol. Kabinlerin kablolarla asılı olduğu taşımacılık.
        /// </summary>
        AerialLift = 6,

        /// <summary>
        /// 7 - Füniküler. Dik yokuşlar için tasarlanmış raylı sistem.
        /// </summary>
        Funicular = 7,

        /// <summary>
        /// 11 - Troleybüs. Havai hatlardan enerji alan elektrikli otobüs.
        /// </summary>
        Trolleybus = 11,

        /// <summary>
        /// 12 - Monoray. Tek ray veya kiriş üzerinde çalışan demiryolu.
        /// </summary>
        Monorail = 12,
    }
}
