﻿using System;

using Microsoft.Extensions.DependencyInjection;

using Scorpio.ObjectMapping.TestClasses;

using Shouldly;

using Xunit;

namespace Scorpio.ObjectMapping
{
    public class DefaultObjectMapperContextTests : ObjectMappingTestBase
    {
        [Fact]
        public void Map()
        {
            var mapper = ServiceProvider.GetRequiredService<IObjectMapper<ObjectMappingContext>>();
            Should.NotThrow(() => mapper.Map<SpecificObjectMapperSource, SpecificObjectMapperDest>(null)).ShouldBeNull();
            Should.NotThrow(() => mapper.Map<SpecificObjectMapperSource, SpecificObjectMapperDest>(new SpecificObjectMapperSource())).ShouldNotBeNull();
            Should.NotThrow(() => mapper.Map<MapToSource, MapToDest>(new MapToSource())).ShouldNotBeNull();
            Should.NotThrow(() => mapper.Map<MapFromSource, MapFromDest>(new MapFromSource())).ShouldNotBeNull();
            Should.Throw<NotImplementedException>(() => mapper.Map<MapFromSource, MapFromDestException>(new MapFromSource())).ShouldNotBeNull();
            Should.Throw<NotImplementedException>(() => mapper.Map<MapSource, MapDest>(new MapSource())).ShouldNotBeNull();
        }

        [Fact]
        public void MapExists()
        {
            var mapper = ServiceProvider.GetRequiredService<IObjectMapper<ObjectMappingContext>>();
            Should.NotThrow(() => mapper.Map<SpecificObjectMapperSource, SpecificObjectMapperDest>(null, null)).ShouldBeNull();
            Should.NotThrow(() => mapper.Map<SpecificObjectMapperSource, SpecificObjectMapperDest>(null, new SpecificObjectMapperDest())).ShouldBeNull();
            Should.NotThrow(() => mapper.Map(new SpecificObjectMapperSource(), new SpecificObjectMapperDest())).ShouldNotBeNull();
            Should.NotThrow(() => mapper.Map(new MapToSource(), new MapToDest())).ShouldNotBeNull();
            Should.NotThrow(() => mapper.Map(new MapFromSource(), new MapFromDest(default))).ShouldNotBeNull();
            Should.Throw<NotImplementedException>(() => mapper.Map(new MapSource(), new MapDest())).ShouldNotBeNull();
        }

        [Fact]
        public void MapExtensions()
        {
            var mapper = ServiceProvider.GetRequiredService<IObjectMapper<ObjectMappingContext>>();
            Should.NotThrow(() => mapper.Map(typeof(MapToSource),typeof(MapToDest), new MapToSource())).ShouldNotBeNull();
            Should.NotThrow(() => mapper.Map(typeof(MapToSource),typeof(MapToDest), new MapToSource(), new MapToDest())).ShouldNotBeNull();
        }
    }
}