using UnityEngine;

namespace MyRI.UIScripts
{
    public class PausePopup : BaseWindow
    {
        public void YesButtonClick()
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
