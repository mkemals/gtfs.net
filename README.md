# gtfs.net

Tüm GTFS ve GTFS-Flex spesifikasyonunu içeren model altyapısı.

[GTFS Schedule Reference](https://gtfs.org/documentation/schedule/reference/) içindeki **32 dosyanın tamamı** için C# sınıfları, alan değerleri için **26 enum** ve her dosya/alanın GTFS meta verisini (bulunma koşulu, alan adı, anahtar bilgisi, varsayılan değer) taşıyan **attribute**'ler içerir. Tüm açıklamalar Türkçedir.

- Namespace: `AJP.Gtfs.Entities`
- Hedef: `netstandard2.1` (.NET Core 3.0+, .NET 5/6/7/8+), C# 8+ (nullable reference types)
- Harici bağımlılık yok

## Klasör yapısı

```
gtfs.net/
├── AGtfsEntity.cs          # Tüm varlıkların türediği abstract temel sınıf
├── AJP.Gtfs.csproj
├── Attributes/
│   ├── GtfsFileNameAttribute.cs
│   ├── GtfsFieldNameAttribute.cs
│   ├── PresenceAttribute.cs
│   └── PresenceType.cs
├── Entities/               # GTFS dosyası başına bir sınıf (32 adet)
│   ├── Agency.cs
│   ├── Stop.cs
│   └── ...
└── Enums/                  # Enum tipindeki alanlar için tipler (26 adet)
    ├── RouteType.cs
    └── ...
```

## Örnek

```csharp
/// <summary>
/// Bu dosya, veri kümesinin açıkladığı hizmetler yerine veri kümesinin kendisiyle ilgili bilgileri (yayıncı, sürüm, geçerlilik süresi) içerir.
/// ...
/// </summary>
[Presence(PresenceType.ConditionallyRequired)]
[GtfsFileName("feed_info")]
public class FeedInfo : AGtfsEntity
{
    /// <summary>
    /// Veri kümesindeki metinler için kullanılan varsayılan dil.
    /// </summary>
    [Presence(PresenceType.Required)]
    [GtfsFieldName("feed_lang")]
    public string FeedLang { get; set; } = string.Empty;
    ...
}

public class StopTime : AGtfsEntity
{
    [Presence(PresenceType.Required)]
    [GtfsFieldName("trip_id", PrimaryKey: true, ForeignKey: true)]
    public string TripId { get; set; } = string.Empty;

    [Presence(PresenceType.ConditionallyForbidden)]
    [GtfsFieldName("pickup_type")]
    [DefaultValue(PickupDropOffType.Regular)]
    public PickupDropOffType PickupType { get; set; } = PickupDropOffType.Regular;
    ...
}
```

## Attribute'ler

| Attribute | Hedef | Açıklama |
| --- | --- | --- |
| `[GtfsFileName("stops")]` | Sınıf | Karşılık gelen GTFS dosyası (uzantısız). `Extension` varsayılanı `.txt`; `FullName` → `stops.txt`. `locations` için `Extension = ".geojson"`. |
| `[GtfsFieldName("stop_id", PrimaryKey, ForeignKey, UniqueKey)]` | Property | GTFS alan (sütun) adı ve anahtar bilgileri. |
| `[Presence(PresenceType.Required)]` | Sınıf, Property | Dosyanın/alanın bulunma koşulu. |
| `[DefaultValue(...)]` | Property | `System.ComponentModel.DefaultValueAttribute`. Yalnızca spesifikasyonun varsayılan değer tanımladığı alanlarda bulunur (ör. `route_color` → `"FFFFFF"`). Property de bu değerle başlatılır. |

**`PresenceType`**: `Required`, `Optional`, `ConditionallyRequired`, `ConditionallyForbidden`, `Recommended`.

**Anahtar bayrakları** (`GtfsFieldName`):

- `PrimaryKey` — Dosyanın "Primary key" tanımındaki alanlar. Bileşik anahtarlarda tüm parçalar işaretlidir; `Primary key (*)` olan dosyalarda tüm alanlar PK'dir; `feed_info` için PK yoktur.
- `ForeignKey` — Tipi *Foreign ID* olan alanlar (başka dosyadaki bir kimliğe başvurur).
- `UniqueKey` — Tipi *Unique ID* olan alanlar (dosya içinde benzersiz).

## Dosyalar ve sınıflar

| GTFS dosyası | Sınıf | Presence | Birincil anahtar | Alan | Flex |
| --- | --- | --- | --- | ---: | :---: |
| `agency.txt` | `Agency` | Required | agency_id | 9 | |
| `stops.txt` | `Stop` | ConditionallyRequired | stop_id | 16 | |
| `routes.txt` | `Route` | Required | route_id | 14 | |
| `trips.txt` | `Trip` | Required | trip_id | 13 | kısmi |
| `stop_times.txt` | `StopTime` | Required | trip_id, stop_sequence | 18 | kısmi |
| `calendar.txt` | `Calendar` | ConditionallyRequired | service_id | 10 | |
| `calendar_dates.txt` | `CalendarDate` | ConditionallyRequired | service_id, date | 3 | |
| `fare_attributes.txt` | `FareAttribute` | Optional | fare_id | 7 | |
| `fare_rules.txt` | `FareRule` | Optional | tüm alanlar (*) | 5 | |
| `timeframes.txt` | `Timeframe` | Optional | tüm alanlar (*) | 4 | |
| `rider_categories.txt` | `RiderCategory` | Optional | rider_category_id | 4 | |
| `fare_media.txt` | `FareMedia` | Optional | fare_media_id | 3 | |
| `fare_products.txt` | `FareProduct` | Optional | fare_product_id, rider_category_id, fare_media_id | 6 | |
| `fare_leg_rules.txt` | `FareLegRule` | Optional | network_id, from_area_id, to_area_id, from_timeframe_group_id, to_timeframe_group_id, fare_product_id | 8 | |
| `fare_leg_join_rules.txt` | `FareLegJoinRule` | Optional | — | 4 | |
| `fare_transfer_rules.txt` | `FareTransferRule` | Optional | from_leg_group_id, to_leg_group_id, fare_product_id, transfer_count, duration_limit | 7 | |
| `areas.txt` | `Area` | Optional | area_id | 2 | |
| `stop_areas.txt` | `StopArea` | Optional | tüm alanlar (*) | 2 | |
| `networks.txt` | `Network` | ConditionallyForbidden | network_id | 2 | |
| `route_networks.txt` | `RouteNetwork` | ConditionallyForbidden | route_id | 2 | |
| `shapes.txt` | `Shape` | ConditionallyRequired | shape_id, shape_pt_sequence | 5 | |
| `frequencies.txt` | `Frequency` | Optional | trip_id, start_time | 5 | |
| `transfers.txt` | `Transfer` | Optional | from_stop_id, to_stop_id, from_trip_id, to_trip_id, from_route_id, to_route_id | 8 | |
| `pathways.txt` | `Pathway` | Optional | pathway_id | 12 | |
| `levels.txt` | `Level` | ConditionallyRequired | level_id | 3 | |
| `location_groups.txt` | `LocationGroup` | Optional | location_group_id | 2 | ✓ |
| `location_group_stops.txt` | `LocationGroupStop` | Optional | tüm alanlar (*) | 2 | ✓ |
| `locations.geojson` | `Location` | Optional | — | 6 | ✓ |
| `booking_rules.txt` | `BookingRule` | Optional | booking_rule_id | 15 | ✓ |
| `translations.txt` | `Translation` | Optional | table_name, field_name, language, record_id, record_sub_id, field_value | 7 | |
| `feed_info.txt` | `FeedInfo` | ConditionallyRequired | yok (dosya yalnızca tek satır içerebilir) | 9 | |
| `attributions.txt` | `Attribution` | Optional | attribution_id | 11 | |

## Tip eşlemesi

| GTFS tipi | C# tipi |
| --- | --- |
| ID, Text, URL, Email, Phone number, Timezone, Language code, Color, Currency code | `string` |
| Date (`YYYYMMDD`), Time / Local time (`HH:MM:SS`) | `string` — GTFS saatleri 24:00:00'ı aşabilir (ör. `25:35:00`) |
| Integer (Non-negative, Positive, Non-zero…) | `int` |
| Float, Latitude, Longitude | `double` |
| Currency amount, `fare_attributes.price` | `decimal` |
| Enum | İlgili C# enum'u (`translations.table_name` → `string`, `pathways.max_slope` → `double`) |

- **Required** alanlar nullable değildir; diğer tüm alanlar nullable'dır (`string?`, `int?`, `RouteType?` …).
- Varsayılan değeri olan alanlar nullable değildir ve o değerle başlatılır.
- `translations.translation` alanı, sınıf adıyla çakışmaması için `TranslatedValue` olarak adlandırılmıştır.

## GTFS-Flex

GTFS-Flex, resmi GTFS Schedule spesifikasyonunun parçası olarak tamamen desteklenir:

- `Location` (`locations.geojson`) — talebe bağlı hizmet bölgeleri. Sınıf, FeatureCollection içindeki tek bir **Feature**'ı temsil eder; alan adları `properties.stop_name`, `geometry.type`, `geometry.coordinates` gibi JSON yoludur. `Polygon` geometrisi tek poligonlu bir `MultiPolygon` olarak `double[][][][]` içinde tutulur (`[poligon][halka][nokta][boylam, enlem]`).
- `LocationGroup`, `LocationGroupStop`, `BookingRule`
- `StopTime`: `location_group_id`, `location_id`, `start_pickup_drop_off_window`, `end_pickup_drop_off_window`, `pickup_booking_rule_id`, `drop_off_booking_rule_id`
- `Trip`: `safe_duration_factor`, `safe_duration_offset`

## Reflection ile kullanım

```csharp
using System.ComponentModel;
using System.Reflection;
using AJP.Gtfs.Entities;

var type = typeof(Stop);
var file = type.GetCustomAttribute<GtfsFileNameAttribute>()!;
Console.WriteLine(file.FullName); // stops.txt

foreach (var prop in type.GetProperties())
{
    var field    = prop.GetCustomAttribute<GtfsFieldNameAttribute>()!;
    var presence = prop.GetCustomAttribute<PresenceAttribute>()!;
    var @default = prop.GetCustomAttribute<DefaultValueAttribute>();

    Console.WriteLine($"{field.FieldName,-22} {presence.Presence,-22} " +
                      $"PK={field.PrimaryKey} FK={field.ForeignKey} UK={field.UniqueKey} " +
                      $"Default={@default?.Value}");
}
```

## Derleme

```bash
dotnet build
```

## Bilinen sınırlar

- **Koşullu kurallar doğrulanmaz.** `ConditionallyRequired` / `ConditionallyForbidden` koşulları (ör. "`location_id` doluysa `stop_id` yasaktır") yalnızca attribute ve XML açıklamalarında belgelenmiştir; doğrulama yükleyici/validator katmanında yapılmalıdır.
- **Eski Flex taslak alanları** (resmi spesifikasyona girmemiş Flex v2 alanları) dahil değildir.
- CSV/GeoJSON okuma-yazma bu projenin kapsamında değildir; sınıflar yalnızca modeldir.
- `RouteType` yalnızca temel hat türlerini içerir; genişletilmiş hat türleri (100–1702) `(RouteType)int` dönüşümüyle taşınabilir.

## Kaynak

[GTFS Schedule Reference — gtfs.org](https://gtfs.org/documentation/schedule/reference/)
