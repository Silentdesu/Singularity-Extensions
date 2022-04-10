namespace SingularityLab.Runtime.Scenes
{
    public ref struct SceneButtonParams
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
    
        public SceneButtonParams(in string name, in string path)
        {
            Name = name;
            Path = path;
        }
    }
}