using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SDFSF");
        GetComponent<Rigidbody2D>().gravityScale = 1; 
    }
}
