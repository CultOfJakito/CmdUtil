using System;
using System.Collections.Generic;
using System.Text;

namespace CmdUtil;

[RegisterCommand]
public sealed class TestCommand : CommandBase {
	public override string Description => "Example Command";

	protected override string Prefix => "cmd_";

	public override void Execute(GameConsole.Console con, string[] args) {
		con.PrintLine("Hello, World!");
	}
}
