global using StronglyTypedIds;

[assembly: StronglyTypedIdDefaults(
    backingType: StronglyTypedIdBackingType.Int,
    converters: StronglyTypedIdConverter.SystemTextJson | StronglyTypedIdConverter.EfCoreValueConverter | StronglyTypedIdConverter.TypeConverter
)] 