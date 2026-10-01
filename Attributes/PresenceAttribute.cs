// GTFS Schedule Reference (https://gtfs.org/documentation/schedule/reference/) temel alınarak oluşturulmuştur.

using System;

namespace AJP.Gtfs.Entities
{
    /// <summary>
    /// GTFS dosyasının (sınıf) veya alanının (property) bulunma koşulunu belirtir.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class PresenceAttribute : Attribute
    {
        public PresenceAttribute(PresenceType presence)
        {
            Presence = presence;
        }

        /// <summary>Bulunma koşulu.</summary>
        public PresenceType Presence { get; }

        public bool IsRequired => Presence == PresenceType.Required;
    }
}
