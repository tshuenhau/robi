using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour //! Might need to find a more efficient way of doing this
{
    [SerializeField] float obstacleSize = 2f;
    [SerializeField] float speed = 5f;
    [SerializeField] string direction = "r";
    [SerializeField] GameObject lastObstacle;

    Vector2 startPos;
    float halfWidth;

    float outOfScreen;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //float halfHeight = Camera.main.orthographicSize;
        // halfWidth = camera.aspect *halfHeight;
        halfWidth = FindObjectOfType<ViewportHandler>().GetFullWidthUnits() / 2;
        //obstacles = GetComponentInChildren<Transform>();
        outOfScreen = obstacleSize / 2 + halfWidth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = startPos;
        if (direction == "l")
        {
            pos.x -= Time.time * speed;
        }
        else
        {
            pos.x += Time.time * speed;
        }
        transform.position = pos;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (direction == "r" && child.position.x >= outOfScreen)
            {
                child.position = new Vector2(lastObstacle.transform.position.x - obstacleSize, lastObstacle.transform.position.y);
                lastObstacle = child.gameObject;
            }
            else if (direction == "l" && child.position.x <= -outOfScreen)
            {
                child.position = new Vector2(lastObstacle.transform.position.x + obstacleSize, lastObstacle.transform.position.y);
                lastObstacle = child.gameObject;
            }
        }
        /*
        foreach (Transform obstacle in transform) //! replace this with a normal for loop
        {
            //Debug.Log(obstacle.name);
            if (direction == "r" && obstacle.position.x >= obstacleSize / 2 + halfWidth)
            {
                obstacle.position = new Vector2(lastObstacle.transform.position.x - obstacleSize, lastObstacle.transform.position.y);
                lastObstacle = obstacle.gameObject;
            }
            else if (direction == "l" && obstacle.position.x <= -obstacleSize / 2 - halfWidth)
            {
                obstacle.position = new Vector2(lastObstacle.transform.position.x + obstacleSize, lastObstacle.transform.position.y);
                lastObstacle = obstacle.gameObject;
            }

        }
        */
    }

}

/*
Vector2 pos = startPos;
        if(startDirection == "l"){
            pos.x += distance * Mathf.Cos(Time.time*speed);
        }
        else{
            pos.x += distance * Mathf.Sin(Time.time*speed);
        }
        transform.position = pos;
*/