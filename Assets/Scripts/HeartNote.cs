using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartNote : MonoBehaviour
{
    public float Speed = 1f;

    void Update()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
    }
}
