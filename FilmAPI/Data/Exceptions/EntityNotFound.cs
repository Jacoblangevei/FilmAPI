namespace FilmAPI.Data.Exceptions
{
    public class EntityNotFound : Exception
    {
        public EntityNotFound(string type, int id)
           : base($"{type} with Id: {id} could not be found.")
        {
        }

    }
}
