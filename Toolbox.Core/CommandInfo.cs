namespace Toolbox.Core;

public record CommandInfo(
    string Command, 
    string? Arguments, 
    bool HasAdmin = false);