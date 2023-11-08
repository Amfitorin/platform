using UnityEngine;

namespace MyRI.UIScripts
{
    /// <summary>
    /// popup opened when character is death
    /// </summary>
    public class FailPopup : BaseWindow
    {
        /// <summary>
        /// restart button handler
        /// </summary>
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

        /// <summary>
        /// cancel game handler
        /// </summary>
        public void OnNoClicked()
        {
            OnCloseWindowClick();
            Application.LoadLevel(Application.loadedLevel);
            Time.timeScale = 1f;
        }
    }
}
