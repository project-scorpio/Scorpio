namespace Microsoft.Extensions.DependencyInjection
{
    internal class Service2 : IService2
    {
        public Service1 Service1 { get; set; }
    }
}