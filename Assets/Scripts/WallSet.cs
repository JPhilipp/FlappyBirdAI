using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSet : MonoBehaviour
{
    const float speed = 2.5f;
    const float outerEdge = 125f;
    const float verticalFuzzy = 12f;

    void Awake()
    {
        RandomizeVerticalPosition();
    }

    void Update()
    {
        Vector3 position = transform.position;
        position.z += speed * Time.deltaTime;
        transform.position = position;
        
        if (position.z >= outerEdge)
        {
            position.z = -outerEdge;
            transform.position = position;
            RandomizeVerticalPosition();
        }
    }
    
    void RandomizeVerticalPosition()
    {
        Vector3 position = transform.localPosition;
        position.y = Random.Range(-verticalFuzzy, verticalFuzzy);
        transform.localPosition = position;
    }
}
