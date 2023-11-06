using System.Diagnostics;

namespace Toolbox.Core;

public class CommandService : ICommandService
{
    public void ExecuteCommand(string command, string? arguments, bool asAdmin)
    {
        using var process = new Process();
        
        process.StartInfo.FileName = command;
        process.StartInfo.Arguments = arguments ?? string.Empty;
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.CreateNoWindow = true;
        
        if(asAdmin)
            process.StartInfo.Verb =  "runas";
        
        process.Start();
    }

    public void ExecuteCommand(CommandInfo commandInfo)
    {
        ExecuteCommand(commandInfo.Command, commandInfo.Arguments, commandInfo.HasAdmin);
    }

    public void ExecuteCommands(CommandInfo[] commandInfos)
    {
        foreach (var commandInfo in commandInfos)
        {
            ExecuteCommand(commandInfo);
        }
    }
}