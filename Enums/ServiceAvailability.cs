// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// Hizmetin haftanın ilgili gününde çalışıp çalışmadığı.
    /// </summary>
    public enum ServiceAvailability
    {
        /// <summary>
        /// 0 - Tarih aralığındaki bu günlerde hizmet yoktur.
        /// </summary>
        NotAvailable = 0,

        /// <summary>
        /// 1 - Tarih aralığındaki bu günlerin tümünde hizmet vardır.
        /// </summary>
        Available = 1,
    }
}
