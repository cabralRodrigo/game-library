global using StronglyTypedIds;
using System.Reflection;

[assembly: StronglyTypedIdDefaults(
    backingType: StronglyTypedIdBackingType.Int,
    converters: StronglyTypedIdConverter.SystemTextJson | StronglyTypedIdConverter.EfCoreValueConverter | StronglyTypedIdConverter.TypeConverter
)]

[assembly: AssemblyTitle("GameLibrary.Domain")]
[assembly: AssemblyProduct("GameLibrary.Domain")] 