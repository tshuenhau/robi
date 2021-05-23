using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour //! Might need to find a more efficient way of doing this
{
    [SerializeField] float obstacleSize = 2f;
    [SerializeField] float speed = 5f;
    [SerializeField] string direction = "r";
    [SerializeField] GameObject lastObstacle;
    private bool update = false;
    Vector2 startPos;
    float halfWidth;

    float outOfScreen;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //transform.position = startPos;
        halfWidth = FindObjectOfType<ViewportHandler>().GetFullWidthUnits() / 2;
        //obstacles = GetComponentInChildren<Transform>();
        outOfScreen = obstacleSize / 2 + halfWidth;
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector2 pos = startPos;
        if (direction == "l")
        {
            pos.x -= Time.timeSinceLevelLoad * speed;
        }
        else
        {
            pos.x += Time.timeSinceLevelLoad * speed;
        }
        transform.position = pos;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i).transform;
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
    }
}
