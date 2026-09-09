using Microsoft.Extensions.DependencyInjection;
using Plugin.Uno.MVVMExpress.Auth;
using Plugin.Uno.MVVMExpress.ComponentModel;
using Plugin.Uno.MVVMExpress.Generated;

namespace Plugin.Uno.MVVMExpress.Core.Tests.Hosting;

public sealed class GeneratedRegistrationHooksTests
{
    [Fact]
    public void Apply_RegistersViewModelsFromModule()
    {
        GeneratedRegistrationHooks.Add(new TestModule());
        var services = new ServiceCollection();
        GeneratedRegistrationHooks.Apply(services);
        using var provider = services.BuildServiceProvider();
        Assert.NotNull(provider.GetService<HookVm>());
    }

    private sealed class HookVm : ViewModel;

    private sealed class TestModule : IGeneratedMvvmExpressModule
    {
        public void AddViewModels(IServiceCollection services)
            => services.AddTransient<HookVm>();

        public void ApplyRoutes(Action<Type, string> map)
            => map(typeof(HookVm), "hook");

        public INavigationAuthPolicy AuthPolicy { get; } = new NavigationAuthPolicy();
    }
}
