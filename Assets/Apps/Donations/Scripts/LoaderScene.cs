using System.Collections;
namespace Trophies.Donations
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LoaderScene : MonoBehaviour
    {
        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}