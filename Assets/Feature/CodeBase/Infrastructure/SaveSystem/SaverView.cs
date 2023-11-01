using Feature.CodeBase.Infrastructure.SaveSystem;
using UnityEngine;
using Zenject;

public class SaverView : MonoBehaviour
{
    private IResSaver saver;

    [Inject]
    private void Init(IResSaver saver)
    {
        this.saver = saver;
    }

    public void Save()
    {
        saver.SaveRes();
    }
}
