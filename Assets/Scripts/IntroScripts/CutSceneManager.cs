using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    private GameObject player;
    private float startTime;
    private bool textUp;
    private float step;

    public Transform target;
    public GameObject dialogTree;
    public BlackFadeControl bfc;
    [Range(3, 6)]
    public float dialogStartTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startTime = 0f;
        textUp = false;
        step = Vector3.Distance(player.transform.position, target.position) / dialogStartTime;
    }

    void Update()
    {
        startTime += Time.deltaTime;

        // After time put first text up
        if (!textUp && startTime > dialogStartTime)
        {
            dialogTree.transform.GetChild(0).gameObject.SetActive(true);
            dialogTree.transform.GetChild(1).gameObject.SetActive(true);
            dialogTree.transform.GetChild(4).gameObject.SetActive(true);
            textUp = true;
        }
        // After space pressed, second text up
        else if (Input.GetKeyDown(KeyCode.Space) && textUp && dialogTree.transform.GetChild(1).gameObject.activeSelf == true)
        {
            dialogTree.transform.GetChild(1).gameObject.SetActive(false);
            dialogTree.transform.GetChild(2).gameObject.SetActive(true);
        }
        // After space pressed, third text up
        else if (Input.GetKeyDown(KeyCode.Space) && textUp && dialogTree.transform.GetChild(2).gameObject.activeSelf == true)
        {
            dialogTree.transform.GetChild(2).gameObject.SetActive(false);
            dialogTree.transform.GetChild(3).gameObject.SetActive(true);
        }
        // Load next scene
        else if (Input.GetKeyDown(KeyCode.Space) && textUp && dialogTree.transform.GetChild(3).gameObject.activeSelf == true)
        {
            dialogTree.transform.GetChild(0).gameObject.SetActive(false);
            dialogTree.transform.GetChild(3).gameObject.SetActive(false);
            dialogTree.transform.GetChild(4).gameObject.SetActive(false);
            bfc.BeginFadeOut();
        }

        // Move player to targer spot
        if (Vector3.Distance(player.transform.position, target.position) >= 0.01f)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, target.position, step * Time.deltaTime);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
