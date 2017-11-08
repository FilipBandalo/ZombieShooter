using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelLoad : MonoBehaviour
{
    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}

