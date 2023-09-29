namespace FilmAPI.Data.Exceptions
{
    public class EntityNotFound : Exception
    {
        public EntityNotFoundException(string type, int id)
           : base($"{type} with Id: {id} could not be found.")
        {
        }

    }
}
