using System;
using System.Collections;
using MyRI.Mechanics.LoopCycle;
using MyRI.UIScripts;
using UnityEngine;

namespace MyRI
{
    
    /// <summary>
    /// god scene objects with links to main window elements
    /// </summary>
    public class SceneStarter : MonoBehaviour
    {
        private static SceneStarter _instance;
        public FailPopup Fail;
        public GameplayHUD HUD;
        public HelpPopup Help;
        public LogoWindow Logo;
        public MainMenuWindow MainM;
        public PausePopup Pause;
        public VictoryPopup Vic;
        public MapSpawner MapSpawner;

        public UpdateProvider UpdateProvider { get; private set; }

        public static SceneStarter Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                _instance = FindObjectOfType<SceneStarter>();
                if (_instance != null)
                {
                    _instance.InitUpdateProvider();
                }
                return _instance;
            }
        }

        private void Awake()
        {
            OpenWithWait(MainM, 3f);
            InitUpdateProvider();
        }

        private void InitUpdateProvider()
        {
            if (UpdateProvider != null)
                return;
            UpdateProvider = new UpdateProvider();
        }

        public void OpenPopup(BaseWindow window, bool state)
        {
            window.gameObject.SetActive(state);
        }

        private void OpenWithWait(BaseWindow window, float time)
        {
            StartCoroutine(Wait(time, () => { window.gameObject.SetActive(true); }));
        }

        public void WaitCallback(float time, Action callback)
        {
            StartCoroutine(Wait(time, () => { callback?.Invoke(); }));
        }

        private IEnumerator Wait(float time, Action action)
        {
            Logo.gameObject.SetActive(true);
            yield return new WaitForSeconds(time);
            Logo.gameObject.SetActive(false);
            action?.Invoke();
        }
    }
}
