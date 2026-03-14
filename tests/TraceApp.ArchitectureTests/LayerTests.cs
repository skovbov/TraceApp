using FluentAssertions;
using NetArchTest.Rules;

namespace TraceApp.ArchitectureTests;

public class LayerTests : BaseTest
{
    [Fact]
    public void DomainLayer_Should_NotHaveAnyDependencies()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .And()
            .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .And()
            .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void ApplicationLayer_ShouldNotDependOn_PresentationOrInfrastructure()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .And()
            .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void InfrastructureLayer_ShouldNotHaveDependencyOn_PresentationLayer()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .Should()
            .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
}