using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFogScript : MonoBehaviour
{
    private Collider2D playerCollider;
    private float fogSpeed;

    public GameObject player;
    
    void Start()
    {
        playerCollider = player.GetComponent<Collider2D>();

        // Moves half as fast as player
        fogSpeed = player.GetComponent<PlayerMovementScript>().speed / 2;
    }

    // Constantly moves right
    void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * fogSpeed);
    }

    // Player fails when they touch fog
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == playerCollider)
        {
            Debug.Log("The black fog envelops you..");
            GameObject.FindGameObjectWithTag("GM").GetComponent<GMScript>().PlayerFailed();
        }
    }
}
