namespace FilmAPI.Data.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string type, int id)
            : base($"{type} with Id: {id} could not be found.")
        {
            // Constructor logic, if needed
        }
    }

}
