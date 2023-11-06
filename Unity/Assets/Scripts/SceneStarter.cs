using System;
using System.Collections;
using MyRI.Mechanics.LoopCycle;
using MyRI.UIScripts;
using UnityEngine;

namespace MyRI
{
    public class SceneStarter : MonoBehaviour
    {
        public FailPopup Fail;
        public GameplayHUD HUD;
        public HelpPopup Help;
        public LogoWindow Logo;
        public MainMenuWindow MainM;
        public PausePopup Pause;
        public VictoryPopup Vic;
        public MapSpawner MapSpawner;

        private static SceneStarter _instance;
        
        private UpdateProvider _updateProvider;
        public UpdateProvider UpdateProvider => _updateProvider;

        public static SceneStarter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SceneStarter>();
                }
                return _instance;
            }
        }

        public void OpenPopup(BaseWindow window, bool state)
        {
            window.gameObject.SetActive(state);
        }

        private void Awake()
        {
            OpenWithWait(MainM, 3f);
            _updateProvider = new UpdateProvider();
        }

        public void OpenWithWait(BaseWindow window, float time)
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