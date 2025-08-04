using Microsoft.UI;
using Microsoft.UI.Windowing;
using WinRT.Interop;
using Windows.Graphics; 

namespace ClientCRUD.Platforms.Windows.Services;
public partial class WindowServices 
{ 
    public static void SetFullScreen(IWindow window)
    {
        var nativeWindow = window.Handler.PlatformView as Microsoft.UI.Xaml.Window;
        var hWnd = WindowNative.GetWindowHandle(nativeWindow);
        var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
        var appWindow = AppWindow.GetFromWindowId(windowId);

        appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);
    }

    public static void CenterAndResize(IWindow window, int width, int height)
    {
        var nativeWindow = window.Handler.PlatformView as Microsoft.UI.Xaml.Window;
        var hWnd = WindowNative.GetWindowHandle(nativeWindow);
        var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
        var appWindow = AppWindow.GetFromWindowId(windowId);

        var displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Primary);

        int x = (displayArea.WorkArea.Width - width) / 2;
        int y = (displayArea.WorkArea.Height - height) / 2;

        appWindow.MoveAndResize(new RectInt32(x, y, width, height));
    } 
}
