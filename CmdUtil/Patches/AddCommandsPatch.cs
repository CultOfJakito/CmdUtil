using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GameConsole;
using HarmonyLib;
using Console = GameConsole.Console;

namespace CmdUtil.Patches;

[HarmonyPatch(typeof(Console), nameof(Console.Awake))]
static file class AddCommandsPatch {
	private static void Postfix() {
		MainPlugin.logger?.LogInfo($"Searching for commands in {Assembly.GetExecutingAssembly()}");
		RegisterCommands(CommandRegistry.cmds);
	}

	private static void RegisterCommands(IEnumerable<ICommand> cmds) {
		foreach(ICommand cmd in cmds) {
			if(Console.Instance.recognizedCommands.ContainsKey(cmd.Command)) {
				continue;
			}
			Console.Instance.RegisterCommand(cmd);
		}
	}
}
