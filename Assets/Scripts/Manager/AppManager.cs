using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Trophies.PackagesApps
{
    public class AppManager : MonoBehaviour
    {
        private static AppManager _instance;
        public static AppManager Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this);
        }

        public void LoadMainMenu()
        {
            if (Maptek.AppManager.Instance != null)
            {
                Destroy(Maptek.AppManager.Instance.gameObject);
            }

            if (Rappi.GameManager.Instance != null)
            {
                Destroy(Rappi.GameManager.Instance.gameObject);
            }

            if (Trophies.GeneralManager.Instance != null)
            {
                Destroy(Trophies.GeneralManager.Instance.gameObject);
            }

            StartCoroutine(LoadAsyncScene(0, ScreenOrientation.Portrait));
        }

        public void LoadScene(int index, ScreenOrientation orientation)
        {
            //loadingScreen.SetActive(true);

            StartCoroutine(LoadAsyncScene(index, orientation));
        }

        IEnumerator LoadAsyncScene(int index, ScreenOrientation orientation)
        {
            //Scene scene = SceneManager.GetActiveScene();
            //Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);
            //bool isMaptek = (SceneManager.GetActiveScene().buildIndex == 6);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            //if (isMaptek)
            //{
            //    AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(6);

            //    // Wait until the asynchronous scene fully loads
            //    while (!asyncUnload.isDone)
            //    {
            //        yield return null;
            //    }
            //}

            Resources.UnloadUnusedAssets();

            Screen.orientation = orientation;
            //loadingScreen.SetActive(false);
        }
    }
}