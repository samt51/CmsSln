namespace Cms.Shared.Bases.CrossCuttuingConcerns.Middleware.Exceptions
{
    public class ClientSideException : Exception
    {
        public ClientSideException(string message) : base(message)
        {

        }
    }
}
