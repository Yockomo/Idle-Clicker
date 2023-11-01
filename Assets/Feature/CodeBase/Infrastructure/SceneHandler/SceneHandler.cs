using UnityEngine.SceneManagement;

namespace Feature.CodeBase.Infrastructure.SceneHandler
{
    public class SceneHandler : ISceneHandler
    {
        public void LoadScene(IScene scene)
        {
            SceneManager.LoadScene(scene.SceneName);
        }
    }
}