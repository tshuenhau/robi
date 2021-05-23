using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalOscillate : MonoBehaviour
{
    [SerializeField] string startDirection = "r";
    [SerializeField] float speed;
    [SerializeField] float distance;
    Vector2 startPos;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = startPos;
        if (startDirection == "l")
        {
            pos.x += distance * Mathf.Cos(Time.time * speed);
        }
        else
        {
            pos.x += distance * -Mathf.Cos(Time.time * speed);
        }
        transform.position = pos;
    }
}
