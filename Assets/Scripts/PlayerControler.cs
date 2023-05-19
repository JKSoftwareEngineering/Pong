using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public bool lazerShot;
    private bool lazerShotPossible;
    //walls
    public GameObject topWall;
    public GameObject bottomWall;
    //board size and init
    public GameObject highCollider;
    public GameObject lowCollider;
    private float yHigh;
    private float yLow;
    private float yPos;
    private float xPos;
    private float zPos;
    private float xScale;
    private float yScale;
    public float count;
    // Start is called before the first frame update
    void Start()
    {
        yHigh = topWall.transform.position.y - (topWall.transform.localScale.y / 2) - 0.5f;
        yLow = bottomWall.transform.position.y + (bottomWall.transform.localScale.y / 2) + 0.5f;
        zPos = transform.position.z;
        xScale = transform.localScale.x;
        lazerShot = false;
        lazerShotPossible = true;
    }

    // Update is called once per frame
    void Update()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
        yScale = transform.localScale.y;
        if (yPos + (yScale / 2) + 1.5 * transform.localScale.y < yHigh)
        {
            if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 moveTo = new Vector3(xPos, (yPos + speed * Time.deltaTime), zPos);
                transform.position = moveTo;
            }
        }
        if (yPos - (yScale / 2) - 1.5 * transform.localScale.y > yLow)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 moveTo = new Vector3(xPos, (yPos - speed * Time.deltaTime), zPos);
                transform.position = moveTo;
            }
        }
        if(lazerShotPossible)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                lazerShot = true;
                count = 0.0f;
                lazerShotPossible = false;
                float xTemp = transform.localScale.x;
                float yTemp = transform.localScale.y * 0.5f;
                float zTemp = transform.localScale.z;
                transform.localScale = new Vector3(xTemp, yTemp, zTemp);
            }
        }
        if(count>10)
        {
            lazerShotPossible = true;
        }
        count += Time.deltaTime;//+1 per sec
    }
}
