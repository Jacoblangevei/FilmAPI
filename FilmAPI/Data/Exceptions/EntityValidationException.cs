namespace FilmAPI.Data.Exceptions
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException(string? message)
            : base(message)
        {
        }
    }
}
