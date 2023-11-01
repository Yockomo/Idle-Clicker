using Feature.CodeBase.Infrastructure.SceneHandler;

namespace Feature.CodeBase.UI.SceneHandler
{
    public class ChangeSceneToMainMenu : BaseSceneChanger
    {
        public override void LoadNextScene()
        {
            sceneHandler.LoadScene(new MainMenuScene());
        }
    }
}