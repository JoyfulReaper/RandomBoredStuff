namespace TestProject;

public static class InterfaceHelper
{
    public static IEnumerable<Type> GetAllTypesThatImplementInterface<T>()
    {
        var commandTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface);

        return commandTypes;
    }
}