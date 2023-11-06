using UnityEngine;
using UnityEngine.UI;

namespace MyRI.UIScripts
{
    public class MainMenuWindow : BaseWindow
    {
        public Image
            MusicButtonBack; // Кнопка вкл и выкл музыки. Если кнопка в состоянии вкл - спрайт из MusicButtonBackActive, если выкл - спрайт из MusicButtonBackInactive

        public Sprite MusicButtonBackActive;
        public Sprite MusicButtonBackInactive;

        public Toggle MusicToggle;

        public AudioSource MusicSource;

        public void OnPlayButtonClick()
        {
            OnCloseWindowClick();
            SceneStarter.MapSpawner.gameObject.SetActive(false);
            SceneStarter.WaitCallback(3f, () =>
            {
                SceneStarter.OpenPopup(SceneStarter.HUD, true);
                SceneStarter.MapSpawner.gameObject.SetActive(true);
            });
        }

        public void OnHelpButtonClick()
        {
            SceneStarter.OpenPopup(SceneStarter.Help, true);
        }

        public void OnExitButtonClick()
        {
            ResourcesManager.Instance.Release();
            Application.Quit();
        }

        public void OnToggleMusic()
        {
            if (!MusicToggle.isOn)
            {
                MusicSource.Stop();
            } else
            {
                MusicSource.Play();
            }
        }

        public void OnMusicButtonClick()
        {
            // Включает и выключает музыку, которой пока ещё нет. Состояния кнопки меняются, описано для переменной MusicButtonBack
        }
    }
}