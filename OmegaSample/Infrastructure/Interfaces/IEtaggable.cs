namespace OmegaSample.Infrastructure
{
    public interface IEtaggable
    {
        string GetEtag();
    }
}
