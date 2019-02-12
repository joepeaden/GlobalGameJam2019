using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteFogScript : MonoBehaviour
{
    public GameObject collectPanel;

    private Collider2D playerCollider;
    private bool collectionUp;

    void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == playerCollider)
        {
            Debug.Log("You beat the level!");
            //GameObject.FindGameObjectWithTag("GM").GetComponent<GMScript>().PlayerFailed();
            collectionUp = true;
            collectPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (collectionUp && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
    }
}
