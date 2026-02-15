using System.Reflection;

namespace Fanoos.Application;

public class AssemblyReference {
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
