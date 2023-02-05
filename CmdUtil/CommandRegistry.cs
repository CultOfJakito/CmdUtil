using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using GameConsole;

namespace CmdUtil;

public static class CommandRegistry {
	internal static List<ICommand> cmds = new();

	public static void RegisterCommand(ICommand command) {
		cmds.Add(command);
		GameConsole.Console.Instance?.RegisterCommand(command);
	}

	public static void RegisterCommands(IEnumerable<ICommand> commands) {
		foreach(ICommand command in commands) {
			RegisterCommand(command);
		}
	}

	public static void RegisterAllCommands(Assembly asm) {
		MainPlugin.logger?.LogInfo($"Searching for commands in {asm}");
		RegisterCommands(asm.GetTypes()
			.Where(IsPossibleCommand)
			.Select(type => (ICommand)Activator.CreateInstance(type)));
	}

	private static bool IsPossibleCommand(Type type) {
		if(type.IsInterface) {
			return false;
		}

		if(type.IsAbstract) {
			return false;
		}

		//Plugin.logger.LogDebug(type);

		return type.GetCustomAttribute<RegisterCommandAttribute>() != null;
	}
}
