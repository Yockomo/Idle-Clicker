using Feature.CodeBase.Infrastructure.SceneHandler;

namespace Feature.CodeBase.UI.SceneHandler
{
    public class ChangeSceneToPlayScene : BaseSceneChanger
    {
        public override void LoadNextScene()
        {
            sceneHandler.LoadScene(new PlayScene());
        }
    }
}