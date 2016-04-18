using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime;
    }
}
