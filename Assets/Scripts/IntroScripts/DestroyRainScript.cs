using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRainScript : MonoBehaviour
{
    public GameObject rain;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rain"))
            Destroy(collision.gameObject);
    }
}
