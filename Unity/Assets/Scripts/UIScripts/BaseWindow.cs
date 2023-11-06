using UnityEngine;

namespace MyRI.UIScripts
{
    public class BaseWindow : MonoBehaviour
    {
        public SceneStarter SceneStarter;

        public void OnCloseWindowClick()
        {
            SceneStarter.OpenPopup(this, false);
        }
    }
}