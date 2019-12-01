namespace OmegaSample.Models
{
    //Define a class for Ion Collection Type
    public class Collection<T> : Resource
    {
        public T[] Value { get; set; }
    }
}
