namespace Toolbox.UI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int height = 600;
        const int width = 400;
        
        window.Height = height;
        window.Width = width;

        window.MaximumHeight = height;
        window.MinimumHeight = height;

        window.MaximumWidth = width;
        window.MinimumWidth = width;
        
        return window;
    }
}