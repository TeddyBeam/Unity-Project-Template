using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ApplicationLayer.Misc
{
    public class SceneTransporter : MonoBehaviour
    {
        /// <summary>
        /// Reload the currently active scene.
        /// </summary>
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        /// <summary>
        /// If the LoadScene take no parameter, reload the currently active scene.
        /// </summary>
        public void LoadScene()
        {
            ReloadScene();
        }

        /// <summary>
        /// Load a scene with its name.
        /// </summary>
        /// <param name="sceneName">Name of the scene.</param>
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// Load a scene with its index.
        /// </summary>
        /// <param name="sceneIndex">Scene's index, make sure you added it into the build setting.</param>
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
