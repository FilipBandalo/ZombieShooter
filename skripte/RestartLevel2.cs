using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel2 : MonoBehaviour {

    


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
