using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace CmdUtil;

[BepInPlugin(GUID, NAME, VERSION)]
public class MainPlugin : BaseUnityPlugin {
	public const string GUID = "io.github.CultOfJakito.CmdUtil";
	public const string NAME = "CmdUtil";
	public const string VERSION = "1.0.0";

	internal static ManualLogSource? logger;

	private void Awake() {
		logger = Logger;

		new Harmony(GUID).PatchAll();

		CommandRegistry.RegisterAllCommands(Assembly.GetExecutingAssembly());

		logger.LogMessage($"{NAME} v{VERSION} Loaded!");
	}
}
