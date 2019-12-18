using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public void SceneLoader(int SceneIndex) {

        SceneManager.LoadScene(SceneIndex);
    }
    public void ExitGame() {
        //Application.Quit(0);
        //EditorApplication.Exit(0);
        EditorApplication.isPlaying = false;
    }
}
