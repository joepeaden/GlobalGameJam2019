using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMScript : MonoBehaviour
{
    private GameObject player;
    private GameObject blackWall;
    private GameObject mainCamera;

    public GameObject restartPopup;

    // connection currently being encountered
    public static ConnectionChoice activeConnectionChoice;
    public enum InteractionMode { Platformer, Connection };
    public static InteractionMode interactionMode = InteractionMode.Platformer;

    private int checkpoint;
    private GameObject[] checkpoints;

    public GameObject connectionsUI;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        blackWall = GameObject.FindGameObjectWithTag("BlackFog");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        checkpoint = 0;
        checkpoints = GameObject.FindGameObjectsWithTag("Respawn");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            restartPopup.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                restartPopup.SetActive(false);
            }
        }
    }

    public void PlayerFailed()
    {
        // Clear inputs and player movement
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Input.ResetInputAxes();


        if (checkpoint > 0)
            Respawn();
        else
        {
            Time.timeScale = 0;
            restartPopup.SetActive(true);
        }

    }

    public void RestartLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        restartPopup.SetActive(false);

        Time.timeScale = 1.0f;
    }

    public void Respawn()
    {
        // Put player down at checkpoint
        player.transform.position = checkpoints[checkpoint].transform.position;
        mainCamera.transform.position = new Vector3(player.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);

        // Move black wall behind checkpoint
        blackWall.transform.position = new Vector3(player.transform.position.x - 15, player.transform.position.y, 0);
    }

    public void LoadMainMenu()
    {
        Debug.Log("Main Menu");
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        restartPopup.SetActive(false);
    }

    public void ConnectionChoice(bool choice)
    {

        checkpoint++;

        ConnectionUI cui = connectionsUI.GetComponent<ConnectionUI>();
        GameObject[] connectionsUIArray = cui.connectionUIArray;

        if(choice == true)
        {
            if(activeConnectionChoice != null)
            {
                Debug.Log("1");
                //if(connectionArray == null)
                //    connectionArray = new GameObject[5];

                if(activeConnectionChoice.connection != null)
                {
                    Debug.Log("2");
                //    Debug.Log(connectionArray.Length);
                    for(int i = 0; i < connectionsUIArray.Length; i++)
                    {
                        Debug.Log("3");
                        if(cui.IsSlotEmpty(i))
                        {
                            Debug.Log("Array: " + i);
                            //connectionsUIArray[i] = activeConnectionChoice.connection;
                            connectionsUI.GetComponent<ConnectionUI>().UpdateConnectionUI(i, activeConnectionChoice);
                            break;
                        }
                    }
                }
                else
                    Debug.Log("Connection for " + activeConnectionChoice.name + "is null.");
            }
        }
    
        Time.timeScale = 1;

        Destroy(activeConnectionChoice.connectionDialog);

        interactionMode = InteractionMode.Platformer;

        activeConnectionChoice.connection.SetActive(false);
    }

}
