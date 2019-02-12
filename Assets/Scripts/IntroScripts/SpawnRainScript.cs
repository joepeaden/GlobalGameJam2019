using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRainScript : MonoBehaviour
{
    public GameObject rain;

    public float offset;
    [Range(1,5)]
    public int rainPerUpdate;

    void Update()
    {
        for (int i = 0; i < rainPerUpdate; i++)
            Instantiate(rain, new Vector3(Random.Range(-offset, offset), this.transform.position.y, 0), new Quaternion(0, 0, 0, 0));
    }
}
