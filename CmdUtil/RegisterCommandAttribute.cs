using System;
using System.Collections.Generic;
using System.Text;

namespace CmdUtil;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class RegisterCommandAttribute : Attribute {
	public RegisterCommandAttribute() {

	}
}
