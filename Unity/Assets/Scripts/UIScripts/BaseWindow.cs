using UnityEngine;

namespace MyRI.UIScripts
{
    /// <summary>
    /// base ui window
    /// </summary>
    public class BaseWindow : MonoBehaviour
    {
        /// <summary>
        /// Starter for game scene
        /// </summary>
        public SceneStarter SceneStarter;

        /// <summary>
        /// close current window
        /// </summary>
        public void OnCloseWindowClick()
        {
            SceneStarter.OpenPopup(this, false);
        }
    }
}
