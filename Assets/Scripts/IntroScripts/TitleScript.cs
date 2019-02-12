using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public void StartClicked()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
