using System.Reflection;

namespace Fanoos.Modules.Main.Application;

public static class AssemblyReference {
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
