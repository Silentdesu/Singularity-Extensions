namespace SingularityLab.Runtime
{
    public class SceneButtonParams
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
    
        public SceneButtonParams(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}