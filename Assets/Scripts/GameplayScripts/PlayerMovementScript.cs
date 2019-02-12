using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private GMScript gm;

    [Range(3f,15f)]
    public float speed;
    [Range(0.01f,0.99f)]
    public float airSpeed;
    [Range(150,500)]
    public float jumpSpeed;
    [Range(.1f, .2f)]
    public float connectReduct;
    
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GMScript>();
    }

    void Update()
    {

        if (GMScript.interactionMode == GMScript.InteractionMode.Platformer)
        {
            ConnectionUI cui = gm.connectionsUI.GetComponent<ConnectionUI>();
            int count = 0;
            for (int i = 0; i < cui.connectionFullArray.Length; i++)
            {
                if (!cui.IsSlotEmpty(i))
                    count++;
            }

            int num = (count - 3 < 0) ? 0 : count - 3;
            float deduction = num * connectReduct;

            // Moves player right and left; decent good control but bad collisions
            if (TouchingFloor())
                transform.Translate(transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * (speed * (1 - deduction)));
            else
                transform.Translate(transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * (speed * (1 - deduction)) * airSpeed);

            /* Movement through andding force
             if (IsTouchingFloor())
                rb.AddForce(transform.right * speed * Input.GetAxis("Horizontal"));
            else
                rb.AddForce(transform.right * (speed * airSpeedReduction) * Input.GetAxis("Horizontal"));*/

            // Jump with force
            if (Input.GetKeyDown(KeyCode.Space) && TouchingFloor())
            {
                rb.AddForce(transform.up * jumpSpeed);
            }
        }
        else if (GMScript.interactionMode == GMScript.InteractionMode.Connection)
        {
            ;
        }
    }

    private bool TouchingFloor()
    {
        if (bc.IsTouchingLayers(LayerMask.GetMask("PlatformLayer")))
            return true;

        return false;
    }
}
