using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRButton : MonoBehaviour
{
    public string sceneToLoad;

    public void OnButtonClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
