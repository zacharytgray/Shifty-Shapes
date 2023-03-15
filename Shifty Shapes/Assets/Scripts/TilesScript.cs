using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScript : MonoBehaviour
{

    public Vector3 targetPosition;
    public int ID;

    void Awake()
    {
        targetPosition = transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.25f); //moves object smoothly

    }
}
