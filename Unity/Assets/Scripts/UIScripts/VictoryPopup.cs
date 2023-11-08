using UnityEngine;

namespace MyRI.UIScripts
{
    public class VictoryPopup : BaseWindow
    {
        public void OnRestartButtonClick()
        {
            OnCloseWindowClick();
            SceneStarter.MapSpawner.gameObject.SetActive(false);
            Time.timeScale = 1f;
            OnCloseWindowClick();
            SceneStarter.WaitCallback(3f, () =>
            {
                SceneStarter.OpenPopup(SceneStarter.HUD, true);
                SceneStarter.MapSpawner.gameObject.SetActive(true);
            });
        }

        public void OnNoClicked()
        {
            Time.timeScale = 1f;
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
