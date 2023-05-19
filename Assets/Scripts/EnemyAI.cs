using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float speedBy;
    public float range;
    public float moveCount;
    //walls
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject Ball;
    //board size and init
    private float yHigh;
    private float yLow;
    private float zPos;
    private float xScale;
    private float yScale;
    private bool controle;
    public Vector3 nextPos;
    private readonly bool Q = false;
    // Start is called before the first frame update
    void Start()
    {
        yHigh = topWall.transform.position.y - (topWall.transform.localScale.y / 2) - 0.5f;
        yLow = bottomWall.transform.position.y + (bottomWall.transform.localScale.y / 2) + 0.5f;
        zPos = transform.position.z;
        xScale = transform.localScale.x / 2;
        yScale = transform.localScale.y / 2;
        controle = true;
        moveCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Q)
        { 
            if (moveCount > speedBy)
            {
                if (controle)
                {
                    nextPos = new Vector3(transform.position.x, Ball.transform.position.y + Random.Range(range * -1, range), zPos);
                    controle = false;
                    moveCount = 0.0f;
                }
            }
            if (nextPos.y > transform.position.y)
            {
                if (transform.position.y + yScale + 1.5 < yHigh)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, zPos);
                }
            }
            if (nextPos.y < transform.position.y)
            {
                if (transform.position.y - yScale - 1.5 > yLow)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, zPos);
                }
            }
            if (nextPos.y + 0.1f >= transform.position.y || nextPos.y - 0.1f <= transform.position.y)
            {
                controle = true;
            }
            moveCount += 0.05f;
        }
        if (Q)
        {
            if (Ball.transform.position.y - yScale - 1.5 < yLow)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
            }
            else if (Ball.transform.position.y + yScale + 1.5 > yHigh)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, Ball.transform.position.y, zPos);
            }
        }
    }
}
