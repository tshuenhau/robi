using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    [SerializeField] float obstacleSize = 2f;
    [SerializeField]float speed = 5f;
    [SerializeField] string direction = "r";
    [SerializeField] GameObject lastObstacle;
    Vector2 startPos;
    float halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Camera camera = Camera.main;
        float halfHeight= camera.orthographicSize;
       // halfWidth = camera.aspect *halfHeight;
        halfWidth = FindObjectOfType<ViewportHandler>().GetFullWidthUnits()/2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = startPos;
        if(direction == "l"){
            pos.x -= Time.time*speed;
        }
        else{
            pos.x += Time.time*speed;
        }
        transform.position = pos;
        foreach(Transform obstacle in GetComponentInChildren<Transform>()){
            if(direction == "r" && obstacle.transform.position.x >= obstacleSize/2 + halfWidth){
                obstacle.transform.position = new Vector2(lastObstacle.transform.position.x-obstacleSize, lastObstacle.transform.position.y);
                lastObstacle = obstacle.gameObject;
            }
            else if(direction == "l" && obstacle.transform.position.x <= -obstacleSize/2 - halfWidth){
                obstacle.transform.position = new Vector2(lastObstacle.transform.position.x+obstacleSize, lastObstacle.transform.position.y);
                lastObstacle = obstacle.gameObject;
            }
            
        }
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