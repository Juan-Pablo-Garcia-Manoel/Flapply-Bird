using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    float rotateSpeed = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()    
    {
        var gameManager = GameManager.Instance;

        float angle = rotateSpeed * Time.deltaTime;

        if (gameManager.IsGameOver())
        {
            return;
        }

        float x = gameManager.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);
        transform.rotation *= Quaternion.AngleAxis(angle, Vector3.up);

        if (transform.position.x <= -gameManager.obstacleOffsetX)
        {
            Destroy(gameObject);
        }
    }
}
