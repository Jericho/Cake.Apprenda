﻿using System;
using Cake.Apprenda.Tests.ACS.Fixtures;
using Cake.Core;
using Cake.Testing;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS
{
    public sealed class CloudShellToolResolverTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Throw_If_File_System_Is_Null()
            {
                // Given
                var fixture = new CloudShellToolResolverFixture { FileSystem = null };

                // When
                var result = Record.Exception(() => fixture.Resolve());

                // Then
                result.Should().BeOfType<ArgumentNullException>().Which.ParamName.Should().Be("fileSystem");
            }

            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new CloudShellToolResolverFixture { Environment = null };

                // When
                var result = Record.Exception(() => fixture.Resolve());

                // Then
                result.Should().BeOfType<ArgumentNullException>().Which.ParamName.Should().Be("environment");
            }

            [Fact]
            public void Should_Throw_If_Tool_Locator_Is_Null()
            {
                // Given
                var fixture = new CloudShellToolResolverFixture { Tools = null };

                // When
                var result = Record.Exception(() => fixture.Resolve());

                // Then
                result.Should().BeOfType<ArgumentNullException>().Which.ParamName.Should().Be("tools");
            }
        }

        public sealed class TheResolveToolPathMethod
        {
            [Fact]
            public void Should_Throw_If_ACS_Exe_Could_Not_Be_Found()
            {
                // Given
                var fixture = new CloudShellToolResolverFixture();

                // When
                var result = Record.Exception(() => fixture.Resolve());

                // Assert
                result.Should().BeOfType<CakeException>().Which.Message.Should().Be("Could not locate acs.exe.");
            }

            [Fact]
            public void Should_Be_Able_To_Resolve_Path_From_The_Tools_Directory()
            {
                // Given
                var fixture = new CloudShellToolResolverFixture();
                fixture.FileSystem.CreateFile("/Working/tools/acs.exe");

                // When
                var result = fixture.Resolve();

                // Then
                Assert.Equal("/Working/tools/acs.exe", result.FullPath);
            }

            [Fact]
            public void Should_Be_Able_To_Resolve_Path_Via_Environment_Path_Variable_On_Unix()
            {
                // Given
                var fixture = new CloudShellToolResolverFixture();
                fixture.Environment.SetEnvironmentVariable("PATH", "/temp:/stuff/programs:/programs");
                fixture.FileSystem.CreateFile("/stuff/programs/acs.exe");

                // When
                var result = fixture.Resolve();

                // Then
                Assert.Equal("/stuff/programs/acs.exe", result.FullPath);
            }

            [Fact]
            public void Should_Be_Able_To_Resolve_Path_Via_Environment_Path_Variable_On_Windows()
            {
                // Given
                var fixture = new CloudShellToolResolverFixture(FakeEnvironment.CreateWindowsEnvironment());
                fixture.Environment.SetEnvironmentVariable("PATH", "/temp;/stuff/programs;/programs");
                fixture.FileSystem.CreateFile("/stuff/programs/acs.exe");

                // When
                var result = fixture.Resolve();

                // Then
                Assert.Equal("/stuff/programs/acs.exe", result.FullPath);
            }

            [Fact]
            public void Should_Be_Able_To_Resolve_Path_Via_ApprendaACSInstall_Environment_Variable()
            {
                // Given
                var fixture = new CloudShellToolResolverFixture();
                fixture.Environment.SetEnvironmentVariable("ApprendaACSInstall", "/programs");
                fixture.FileSystem.CreateFile("/programs/acs.exe");

                // When
                var result = fixture.Resolve();

                // Then
                Assert.Equal("/programs/acs.exe", result.FullPath);
            }
        }
    }
}
