using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenUIView : GameOverScreenUIViewBase
{
    [SerializeField] private Button uiButtonReturn = null;


    protected override void OnSubscribe()
    {
        uiButtonReturn.onClick.AddListener(OnButtonReturnClick);
    }

    protected override void OnUnsubscribe()
    {
        uiButtonReturn.onClick.RemoveListener(OnButtonReturnClick);
    }

    private void OnButtonReturnClick()
    {
        Presenter.HandleReturnToMainMenuInput();
    }
}