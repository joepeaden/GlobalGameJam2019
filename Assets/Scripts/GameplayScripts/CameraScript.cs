using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    private GameObject fallBox;
    private GameObject whiteFog;
    private float offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fallBox = GameObject.FindGameObjectWithTag("KillBox");
        whiteFog = GameObject.FindGameObjectWithTag("Finish");

        // How far out to stop the camera from end of level
        offset = GetComponent<Camera>().orthographicSize + whiteFog.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    void LateUpdate()
    {
        // Only move the camera right when player tries to move further
        if (player.transform.position.x > this.transform.position.x)
        {
            // Stop camera when at end of the level
            if (transform.position.x <= whiteFog.transform.position.x - offset)
                this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);

        }

        // Keep fall box under the camera
        fallBox.transform.position = new Vector3(this.transform.position.x, fallBox.transform.position.y, 0);
    }
}
