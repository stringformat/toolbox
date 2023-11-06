namespace Toolbox.Core;

public interface ICommandService
{
    void ExecuteCommand(string command, string? arguments, bool asAdmin);
    void ExecuteCommand(CommandInfo commandInfo);
    void ExecuteCommands(CommandInfo[] commandInfos);
}