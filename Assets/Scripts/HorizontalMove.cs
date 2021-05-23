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
        Debug.Log(transform.position + "THIS IS THE POS Start");
        //float halfHeight = Camera.main.orthographicSize;
        // halfWidth = camera.aspect *halfHeight;
        halfWidth = FindObjectOfType<ViewportHandler>().GetFullWidthUnits() / 2;
        //obstacles = GetComponentInChildren<Transform>();
        outOfScreen = obstacleSize / 2 + halfWidth;
        Move();

    }

    private void OnDestroy()
    {
        //Debug.Log(startPos);
        transform.position = startPos;
        Debug.Log(transform.position + "THIS IS THE POS destroy");

    }
    void Update()
    {

        Move();
        if (update == false)
        {
            Debug.Log(transform.position + "THIS IS THE POS");
            update = true;
        }
    }
    void Move() //! the problem here is that the X value keeps increasing to very big numbers
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
