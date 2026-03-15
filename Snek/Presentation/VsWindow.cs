using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Snek.Presentation;

public class VsWindow : Window
{
    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);

        if (!OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17763))
        {
            return;
        }

        var enabled = 1;
        _ = DwmSetWindowAttribute(
            new WindowInteropHelper(this).Handle,
            20,
            ref enabled,
            Marshal.SizeOf<int>());
    }

#pragma warning disable SYSLIB1054
    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(
        nint windowHandle,
        int attribute,
        ref int attributeValue,
        int attributeSize);
#pragma warning restore SYSLIB1054
}
