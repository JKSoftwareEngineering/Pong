using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour
{
    public float speed;
    //direction of the ball
    private float xDirection;
    private float yDirection;
    //board size and init
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject player1Mid;
    public GameObject player2Mid;
    public GameObject player1HighCollider;
    public GameObject player1LowCollider;
    public GameObject player2HighCollider;
    public GameObject player2LowCollider;
    public Light ballLight;
    public Light lightPlayer1;
    public Light lightPlayer1_2;
    public Light lightPlayer2;
    public Light lightPlayer2_2;

    private float yPos;
    private float xPos;
    private float zPos;
    //private vars only
    private int collisionControler;
    private bool keepAtHighAngle = false;

    private float topRange;
    private float bottomRange;
    private float offset;
    private float tempSpeedHolder;
    private float speedIncramentor;

    private float topOfBall;
    private float bottomOfBall;
    private float leftOfBall;
    private float rightOfBall;
    private float xScaleBall;
    private float yScaleBall;

    private float topOfP1;
    private float bottomOfP1;
    private float leftOfP1;
    private float rightOfP1;
    private float xScaleP1;
    private float yScaleP1;

    private float topOfP2;
    private float bottomOfP2;
    private float leftOfP2;
    private float rightOfP2;
    private float xScaleP2;
    private float yScaleP2;

    private float topOfP1HighCollide;
    private float bottomOfP1HighCollide;
    private float topOfP1LowCollide;
    private float bottomOfP1LowCollide;
    private float yScaleP1HighCollider;
    private float yScaleP1LowCollider;
    private float xScaleP1HighCollider;
    private float xScaleP1LowCollider;
    private float rightOfP1HighCollide;
    private float rightOfP1LowCollide;

    private float topOfP2HighCollide;
    private float bottomOfP2HighCollide;
    private float topOfP2LowCollide;
    private float bottomOfP2LowCollide;
    private float yScaleP2HighCollider;
    private float yScaleP2LowCollider;
    private float xScaleP2HighCollider;
    private float xScaleP2LowCollider;
    private float leftOfP2HighCollide;
    private float leftOfP2LowCollide;
    // Start is called before the first frame update
    void Start()
    {
        topRange = topWall.transform.position.y - (topWall.transform.localScale.y / 2);
        bottomRange = bottomWall.transform.position.y + (bottomWall.transform.localScale.y / 2);
        offset = 0.5f;
        zPos = transform.position.z;
        tempSpeedHolder = speed;
        speedIncramentor = 0.5f;

        xScaleBall = transform.localScale.x / 2;
        yScaleBall = transform.localScale.y / 2;
        xScaleP1 = player1Mid.transform.localScale.x / 2;
        yScaleP1 = player1Mid.transform.localScale.y / 2;
        xScaleP2 = player1Mid.transform.localScale.x / 2;
        yScaleP2 = player1Mid.transform.localScale.y / 2;
        yScaleP1HighCollider = player1HighCollider.transform.localScale.y / 2;
        yScaleP1LowCollider = player1LowCollider.transform.localScale.y / 2;
        xScaleP1HighCollider = player1HighCollider.transform.localScale.x / 2 - 0.5f;
        xScaleP1LowCollider = player1LowCollider.transform.localScale.x / 2 - 0.5f;
        yScaleP2HighCollider = player2HighCollider.transform.localScale.y / 2;
        yScaleP2LowCollider = player2LowCollider.transform.localScale.y / 2;
        xScaleP2HighCollider = player2HighCollider.transform.localScale.x / 2 - 0.5f;
        xScaleP2LowCollider = player2LowCollider.transform.localScale.x / 2 - 0.5f;

        //------------------//
        int tempX = Random.Range((int)-1, (int)2);
        int tempY = Random.Range((int)-1, (int)2);
        xDirection = (float)tempX;
        yDirection = (float)tempY;
        if (xDirection == 0.0f)
        {
            xDirection = 1.0f;
        }
        if (yDirection == 0.0f)
        {
            yDirection = 1.0f;
        }
        //==================//
        //yDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        player1HighCollider.transform.position = new Vector3(player1Mid.transform.position.x, player1HighCollider.transform.position.y, player1HighCollider.transform.position.z);
        player1LowCollider.transform.position = new Vector3(player1Mid.transform.position.x, player1LowCollider.transform.position.y, player1LowCollider.transform.position.z);
        player2HighCollider.transform.position = new Vector3(player2Mid.transform.position.x, player2HighCollider.transform.position.y, player2HighCollider.transform.position.z);
        player2LowCollider.transform.position = new Vector3(player2Mid.transform.position.x, player2LowCollider.transform.position.y, player2LowCollider.transform.position.z);

        xPos = transform.position.x;
        yPos = transform.position.y;

        topOfBall = transform.position.y + xScaleBall;
        bottomOfBall = transform.position.y - yScaleBall;
        leftOfBall = transform.position.x - xScaleBall;
        rightOfBall = transform.position.x + yScaleBall;

        topOfP1HighCollide = player1HighCollider.transform.position.y + yScaleP1HighCollider;
        bottomOfP1HighCollide = player1HighCollider.transform.position.y - yScaleP1HighCollider;
        rightOfP1HighCollide = player1HighCollider.transform.position.x - xScaleP1HighCollider;
        topOfP1 = player1Mid.transform.position.y + yScaleP1;
        bottomOfP1 = player1Mid.transform.position.y - yScaleP1;
        leftOfP1 = player1Mid.transform.position.x - xScaleP1;
        rightOfP1 = player1Mid.transform.position.x + xScaleP1;
        topOfP1LowCollide = player1LowCollider.transform.position.y + yScaleP1LowCollider;
        bottomOfP1LowCollide = player1LowCollider.transform.position.y - yScaleP1LowCollider;
        rightOfP1LowCollide = player1LowCollider.transform.position.x - xScaleP1LowCollider;

        topOfP2HighCollide = player2HighCollider.transform.position.y + yScaleP2HighCollider;
        bottomOfP2HighCollide = player2HighCollider.transform.position.y - yScaleP2HighCollider;
        leftOfP2HighCollide = player2HighCollider.transform.position.x - xScaleP2HighCollider;
        topOfP2 = player2Mid.transform.position.y + yScaleP2;
        bottomOfP2 = player2Mid.transform.position.y - yScaleP2;
        leftOfP2 = player2Mid.transform.position.x - xScaleP2;
        rightOfP2 = player2Mid.transform.position.x + xScaleP2;
        topOfP2LowCollide = player2LowCollider.transform.position.y + yScaleP2LowCollider + 0.5f;
        bottomOfP2LowCollide = player2LowCollider.transform.position.y - yScaleP2LowCollider;
        leftOfP2LowCollide = player2LowCollider.transform.position.x - xScaleP2LowCollider;

        LightReset(ballLight, 3.0f);
        LightReset(lightPlayer1, 4.0f);
        LightReset(lightPlayer1_2, 4.0f);
        LightReset(lightPlayer2, 3.0f);
        LightReset(lightPlayer2_2, 3.0f);

        transform.position = new Vector3(xPos + (xDirection * speed) * Time.deltaTime, yPos + (yDirection * speed) * Time.deltaTime, zPos);

        if (TopWallCollision(topOfBall, topRange))
        {
            LightFlash(ballLight, 6.0f);
            yDirection *= -1;
            transform.position = new Vector3(xPos, topRange - offset, zPos);
        }
        if (BottomWallCollision(bottomOfBall, bottomRange))
        {
            LightFlash(ballLight, 6.0f);
            yDirection *= -1;
            transform.position = new Vector3(xPos, bottomRange + offset, zPos);
        }
        //p2 collision
        if (EnemyHighCollision(rightOfBall, leftOfP2, leftOfBall, rightOfP2, yPos, topOfP2HighCollide, bottomOfP2HighCollide) && collisionControler == 0)
        {
            LightFlash(ballLight, 6.0f);
            LightFlash(lightPlayer2, 8.0f);
            xDirection *= -1;
            if (!keepAtHighAngle)
            {
                yDirection *= -0.9f;
            }
            transform.position = new Vector3(leftOfP2 - offset - 0.1f, yPos, zPos);
            speed += speedIncramentor;
            collisionControler = 5;
        }
        if (EnemyCollision(rightOfBall, leftOfP2, leftOfBall, rightOfP2, topOfBall, topOfP2, bottomOfBall, bottomOfP2) && collisionControler == 0)
        {
            LightFlash(ballLight, 6.0f);
            LightFlash(lightPlayer2, 8.0f);
            LightFlash(lightPlayer2_2, 8.0f);
            xDirection *= -1;
            transform.position = new Vector3(leftOfP2 - offset, yPos, zPos);
            speed += speedIncramentor;
            collisionControler = 5;
        }
        if (EnemyLowCollision(rightOfBall, leftOfP2, leftOfBall, rightOfP2, yPos, topOfP2LowCollide, bottomOfP2LowCollide) && collisionControler == 0)
        {
            LightFlash(ballLight, 6.0f);
            LightFlash(lightPlayer2_2, 8.0f);
            xDirection *= -1;
            if (!keepAtHighAngle)
            {
                yDirection *= -0.9f;
            }
            transform.position = new Vector3(leftOfP2 - offset - 0.1f, yPos, zPos);
            speed += speedIncramentor;
            collisionControler = 5;
        }
        //p1 collision
        if (PlayerHighCollision(leftOfBall, rightOfP1, rightOfBall, yPos, topOfP1HighCollide, bottomOfP1HighCollide) && collisionControler == 0)
        {
            LightFlash(ballLight, 6.0f);
            LightFlash(lightPlayer1, 8.0f);
            xDirection *= -1;
            if (!keepAtHighAngle)
            {
                yDirection *= -0.9f;
            }
            transform.position = new Vector3(rightOfP1 + offset + 0.1f, yPos, zPos);
            speed += speedIncramentor;
            collisionControler = 5;
        }
        if (PlayerCollision(leftOfBall, rightOfP1, rightOfBall, topOfBall, topOfP1, bottomOfBall, bottomOfP1) && collisionControler == 0)
        {
            LightFlash(ballLight, 6.0f);
            LightFlash(lightPlayer1, 8.0f);
            LightFlash(lightPlayer1_2, 8.0f);
            xDirection *= -1;
            transform.position = new Vector3(rightOfP1 + offset, yPos, zPos);
            speed += speedIncramentor;
            collisionControler = 5;
        }
        if (PlayerLowCollision(rightOfP1, rightOfBall, leftOfBall, yPos, topOfP1LowCollide, bottomOfP1LowCollide) && collisionControler == 0)
        {
            LightFlash(ballLight, 6.0f);
            LightFlash(lightPlayer1_2, 8.0f);
            xDirection *= -1;
            if (!keepAtHighAngle)
            {
                yDirection *= -0.9f;
            }
            transform.position = new Vector3(rightOfP1 + offset + 0.1f, yPos, zPos);
            speed += speedIncramentor;
            collisionControler = 5;
        }
        GameObject master = GameObject.Find("Master");//runtime accessing test
        //scoring
        if (PlayerScore(leftOfBall, leftOfP1, speed))
        {
            master.GetComponent<ScoreControler>().player2ScoreDisplay += 1;
            Initialize();
        }
        if (EnemyScore(rightOfBall, rightOfP2, speed))
        {
            master.GetComponent<ScoreControler>().player1ScoreDisplay += 1;
            Initialize();
        }
        if(GameObject.Find("Player1").GetComponent<PlayerControler>().lazerShot)
        {
            yDirection *= 0.2f;
            speed += speed * 1.5f;
            GameObject.Find("Player1").GetComponent<PlayerControler>().lazerShot = false;
        }
        // speed cap
        if(speed > 50)
        {
            speed = 50;
        }
        if(collisionControler > 0)
        {
            collisionControler--;
        }
    }
    public void Initialize()
    {
        transform.position = new Vector3(0, 0, -0.5f);
        int tempX = Random.Range((int)-1, (int)2);
        int tempY = Random.Range((int)-1, (int)2);
        xDirection = (float)tempX;
        yDirection = (float)tempY;
        speed = tempSpeedHolder;
        if (xDirection == 0.0f)
        {
            xDirection = 0.5f;
        }
        if (yDirection == 0.0f)
        {
            yDirection = 0.5f;
        }
    }
    public void LightReset(Light l, float min)
    {
        if (l.intensity > min)
        {
            l.intensity -= 0.5f;
        }
    }
    public void LightFlash(Light l, float max)
    {
        l.intensity = max;
    }
    //-----collisions-----//
    public bool TopWallCollision(float topofball, float toprange)
    {
        if (topofball > toprange)
        {
            return true;
        }
        return false;
    }
    public bool BottomWallCollision(float bottomofball, float bottomrange)
    {
        if (bottomofball < bottomrange)
        {
            return true;
        }
        return false;
    }
    public bool PlayerCollision(float leftofball, float rightofp1, float rightofball, float topofball, float topofp1, float bottomofball, float bottomofp1)
    {
        if (leftofball < rightofp1 && topofball < topofp1 && bottomofball > bottomofp1)// && rightofball > leftofball
        {
            return true;
        }
            return false;
    }
    public bool PlayerHighCollision(float leftofball, float rightofp1, float rightofball, float ypos, float topofp1highcollide, float bottomofp1highcollide)
    {
        if (leftofball < rightofp1 && ypos < topofp1highcollide && ypos > bottomofp1highcollide)// && rightofball > leftofball
        {
            return true;
        }
            return false;
    }
    public bool PlayerLowCollision(float rightofp1, float rightofball, float leftofball, float ypos, float topofp1lowcollide, float bottomofp1lowcollide)
    {
        if (leftofball < rightofp1 && ypos < topofp1lowcollide && ypos > bottomofp1lowcollide)// && rightofball > leftofball
        {
            return true;
        }
            return false;
    }
    public bool EnemyCollision(float rightofball, float leftofp2, float leftofball, float rightofp2, float topofball, float topofp2, float bottomofball, float bottomofp2)
    {
        if (rightofball > leftofp2 && topofball < topofp2 && bottomofball > bottomofp2)// && leftofball < rightofp2
        {
            return true;
        }
            return false;
    }
    public bool EnemyHighCollision(float rightofball, float leftofp2, float leftofball, float rightofp2, float ypos, float topofp2highcollide, float bottomofp2highcollide)
    {
        if (rightofball > leftofp2 && ypos < topofp2highcollide && ypos > bottomofp2highcollide)//&& leftofball < rightofp2 
        {
            return true;
        }
            return false;
    }
    public bool EnemyLowCollision(float rightofball, float leftofp2, float leftofball, float rightofp2, float ypos, float topofp2lowcollide, float bottomofp2lowcollide)
    {
        if (rightofball > leftofp2 && ypos < topofp2lowcollide && ypos > bottomofp2lowcollide)//&& leftofball < rightofp2 
        {
            return true;
        }
            return false;
    }
    //--------------------//
    public bool PlayerScore(float leftofball, float leftofp1, float s)
    {
        if(leftofball < leftofp1 - 2)
        {
            return true;
        }
        return false;
    }
    public bool EnemyScore(float rightofball, float rightofp2, float s)
    {
        if (rightofball > rightofp2 + 2)
        {
            return true;
        }
            return false;
    }
}
/*
 * to fix the collision issue between the top bottom and the middle collider add an invisable component that the ball will collide off of between them
 * or remove the player from the equation and have the collision bounce off of the invisable colliders
 */
