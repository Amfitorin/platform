using UnityEngine;

namespace MyRI.UIScripts
{
    public class FailPopup : BaseWindow
    {
        public void OnRestartButtonClick()
        {
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
            OnCloseWindowClick();
            Application.LoadLevel(Application.loadedLevel);
            Time.timeScale = 1f;
        }
    }
}