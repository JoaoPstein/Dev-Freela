using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Core.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ProjectAlreadyStartedException : Exception
    {
        public ProjectAlreadyStartedException() : base("Project already in Started status")
        {

        }
    }
}
