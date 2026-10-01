// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// stops.txt konum türü.
    /// </summary>
    public enum LocationType
    {
        /// <summary>
        /// 0 - Durak veya peron (boş değer de bu anlama gelir). Yolcuların araca bindiği veya indiği yer; parent_station içinde tanımlıysa peron olarak adlandırılır.
        /// </summary>
        StopOrPlatform = 0,

        /// <summary>
        /// 1 - İstasyon. Bir veya daha fazla peron içeren fiziksel yapı veya alan.
        /// </summary>
        Station = 1,

        /// <summary>
        /// 2 - Giriş/Çıkış. Yolcuların sokaktan istasyona girip çıktığı yer.
        /// </summary>
        EntranceExit = 2,

        /// <summary>
        /// 3 - Genel düğüm. İstasyon içinde, geçitleri (pathways) birbirine bağlamak için kullanılan diğer konum.
        /// </summary>
        GenericNode = 3,

        /// <summary>
        /// 4 - Biniş alanı. Peron üzerinde yolcuların araca binip indiği belirli bir alan.
        /// </summary>
        BoardingArea = 4,
    }
}
