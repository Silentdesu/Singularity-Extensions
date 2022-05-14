using SingularityLab.Runtime.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SingularityLab.Runtime.Tutorials
{
    public abstract class BaseTutorialService : MonoBehaviour
    {
        protected readonly List<ITutorial> _tutorials = new List<ITutorial>();

        protected virtual void Awake() { }

        protected virtual void Start()
        {
            foreach (var tutorial in _tutorials)
            {
                if (!tutorial.IncludeInTutorial) continue;
                
                tutorial.Init();
            }
            
            DebugX.Success($"Tutorials has been initialized.");

            StartCoroutine(ExecuteTutorials());
        }

        protected virtual IEnumerator ExecuteTutorials()
        {
            DebugX.Warning(_tutorials.Count == 0? "Tutorials list is empty" : "Tutorial has been started");
            
            foreach (var tutorial in _tutorials)
            {
                if (!tutorial.IncludeInTutorial) continue;
                
                tutorial.Start();
                
                DebugX.OnStart($"{tutorial.GetType().Name} started");
                
                while (!tutorial.Finished)
                {
                    DebugX.Track($"{tutorial.GetType().Name} is running");
                    
                    yield return null;
                }
            }
            
            DebugX.Success("Tutorial has finished");
        }
    }
}