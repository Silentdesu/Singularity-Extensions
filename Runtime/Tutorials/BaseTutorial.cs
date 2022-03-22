using UnityEngine;

namespace SingularityLab.Runtime.Tutorials
{
    public abstract class BaseTutorial : ITutorial
    {
        public virtual bool IncludeInTutorial { get; } = true;
        public virtual bool Finished { get; protected set; } = false;

        protected Camera _camera;

        public BaseTutorial(bool includeInTutorial = true)
        {
            IncludeInTutorial = includeInTutorial;
        }
        
        public virtual void Init()
        {
            _camera = Camera.main;
        }

        public virtual void Start() { }
    }
}