using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace NuvyntraLabs.UnoMVVMExpress.VisualStudio;

[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
[InstalledProductRegistration("Uno MVVMExpress", "Create Uno MVVMExpress apps and pages from Plugin.Uno.MVVMExpress.Templates.", "1.0.0")]
[ProvideMenuResource("Menus.ctmenu", 1)]
[ProvideAutoLoad(UIContextGuids80.NoSolution, PackageAutoLoadFlags.BackgroundLoad)]
[ProvideAutoLoad(UIContextGuids80.SolutionExists, PackageAutoLoadFlags.BackgroundLoad)]
[Guid(UnoMvvmExpressPackage.PackageGuidString)]
public sealed class UnoMvvmExpressPackage : AsyncPackage
{
    public const string PackageGuidString = "a5b6c7d8-8b4d-4e91-9c2a-6f0d8e1b7a44";

    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
    {
        await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        await Commands.InitializeAsync(this).ConfigureAwait(true);
        try
        {
            await DotnetTemplates.EnsureInstalledAsync(cancellationToken).ConfigureAwait(true);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            ActivityLog.LogWarning("Uno MVVMExpress", ex.Message);
        }
    }
}
