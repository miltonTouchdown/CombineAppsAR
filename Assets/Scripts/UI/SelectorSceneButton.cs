using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trophies.PackagesApps
{
    public class SelectorSceneButton : MonoBehaviour
    {
        public int indexScene;
        public ScreenOrientation orientation;

        public void LoadScene()
        {
            AppManager.Instance.LoadScene(indexScene, orientation);
        }

        public void LoadMainMenu()
        {
            AppManager.Instance.LoadMainMenu();
        }
    }
}