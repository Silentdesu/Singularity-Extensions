namespace SingularityLab.Runtime.Tutorials
{
    public interface ITutorial
    {
        bool IncludeInTutorial { get; }
        bool Finished { get; }

        void Init();
        void Start();
    }
}