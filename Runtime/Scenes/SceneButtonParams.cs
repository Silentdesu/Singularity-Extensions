using System;

namespace SingularityLab.Runtime.Scenes
{
    public ref struct SceneButtonParams
    {
        public readonly ReadOnlySpan<char> Name { get; }
        public readonly ReadOnlySpan<char> Path { get; }
    
        public SceneButtonParams(in ReadOnlySpan<char> name, in ReadOnlySpan<char> path)
        {
            Name = name;
            Path = path;
        }
    }
}