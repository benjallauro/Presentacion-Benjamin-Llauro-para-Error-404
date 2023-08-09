using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}