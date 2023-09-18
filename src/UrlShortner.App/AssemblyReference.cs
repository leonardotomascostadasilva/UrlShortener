namespace UrlShortner.App;
public class AssemblyReference
{
    internal static void Assembly(MediatRServiceConfiguration configuration)
    {
        configuration.RegisterServicesFromAssemblyContaining<AssemblyReference>();
    }
}
