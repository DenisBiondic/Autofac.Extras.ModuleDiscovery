﻿using System;
using FluentAssertions;
using Test.AssemblyAReferencingB;
using Xunit;

namespace Autofac.Extras.ModuleDiscovery.Tests
{
    public class ModuleLoadingTests
    {
        [Fact]
        public void ShouldDiscoverAllModulesCorrectly()
        {
            // Arrange
            var containerBuilder = new ContainerBuilder();

            // Act

            //containerBuilder.RegisterAssemblyModules(typeof(ModuleB).Assembly);
            //containerBuilder.RegisterAssemblyModules(typeof(ModuleA).Assembly);
            //containerBuilder.RegisterAssemblyModules(typeof(ModuleC).Assembly);
            containerBuilder.AutoregisterAllReferencedModules("Test");

            // Assert
            var container = containerBuilder.Build();

            Action resolvingAction = () =>
            {
                var aType = container.Resolve<IAType>();
                aType.Should().NotBeNull("should be resolved correctly");
                aType.Should().BeOfType<AType>();
                aType.As<AType>().DummyReference.Should().NotBeNull();
            };

            resolvingAction.ShouldNotThrow("resolving should not throw any exceptions, type must be found");
        }
    }
}
