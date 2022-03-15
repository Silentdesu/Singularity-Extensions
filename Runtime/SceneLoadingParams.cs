using UnityEngine.SceneManagement;

namespace SingularityLab.Runtime
{
    public class SceneLoadingParams
    {
        public string SceneName;
        public LoadSceneMode LoadSceneMode = LoadSceneMode.Additive;
    }
}