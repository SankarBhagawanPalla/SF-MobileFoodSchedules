using Swashbuckle.AspNetCore.Swagger;

namespace MobileFoodSchedules
{
    internal class OpenApiInfo : Info
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}