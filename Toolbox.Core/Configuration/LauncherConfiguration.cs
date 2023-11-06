namespace Toolbox.Core.Configuration;

public class LauncherConfiguration
{
    public string Text { get; set; }
    public CommandInfo[] Commands { get; set; }
    public bool IsFavorite { get; set; } = false;
}