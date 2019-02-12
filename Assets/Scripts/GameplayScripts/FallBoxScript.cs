using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBoxScript : MonoBehaviour
{
    private BoxCollider2D bc;
    private Transform blackFogWall;
    private Transform respawnPoint;

    public bool canRespawn;

    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();
        blackFogWall = GameObject.FindGameObjectWithTag("BlackFog").GetComponent<Transform>();
    }

    // Respawn player if they touch the box
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<PlayerMovementScript>() != null)
        {
            Debug.Log("Oh no, you've fallen off the map!");

            // If player can respawn, do so otherwise fail
            if (canRespawn && blackFogWall.position.x > respawnPoint.position.x)
            {
                collision.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 0);
                collision.GetComponentInParent<Transform>().transform.position = respawnPoint.transform.position;
                Input.ResetInputAxes();
            }
            else
                GameObject.FindGameObjectWithTag("GM").GetComponent<GMScript>().PlayerFailed();
        }
    }
}
