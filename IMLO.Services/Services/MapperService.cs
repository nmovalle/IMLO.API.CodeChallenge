﻿using AutoMapper;
using IMLO.Services.Interfaces;

namespace IMLO.Services.Services;

public class MapperService<TSource, TDestination> : IMapperService<TSource, TDestination>
{
    private readonly IMapper _mapper;

    public MapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map(TSource source, TDestination destination, List<string>? excludeProperties = null)
    {
        var sourceProperties = typeof(TSource).GetProperties();
        var destinationProperties = typeof(TDestination).GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            if (excludeProperties != null && excludeProperties.Contains(sourceProperty.Name))
            {
                continue;
            }

            var destinationProperty = destinationProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);

            if (destinationProperty != null && destinationProperty.CanWrite)
            {
                var value = sourceProperty.GetValue(source, null);
                destinationProperty.SetValue(destination, value, null);
            }
        }

        return destination;
    }

    public TDestination MapToDestination(TSource source)
    {
        return _mapper.Map<TDestination>(source);
    }

    public TSource MapToSource(TDestination destination)
    {
        return _mapper.Map<TSource>(destination);
    }

    public TDestination Map(TSource source, TDestination dest)
    {
        return _mapper.Map(source, dest);
    }
}