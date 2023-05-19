using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreControler : MonoBehaviour
{
    public Text Player1Score;
    public Text Player2Score;
    public Text countDown;
    public int player1ScoreDisplay;
    public int player2ScoreDisplay;
    public GameObject player1Death;
    public GameObject player2Death;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Ball;
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        player1ScoreDisplay = 0;
        player2ScoreDisplay = 0;
        SetCountText();
        counter = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        SetCountText();
        if(player1ScoreDisplay == 10)
        {
            player2Death.gameObject.SetActive(true);
        }
        if (player2ScoreDisplay == 10)
        {
            player1Death.gameObject.SetActive(true);
        }
        if (counter < 3 && counter > 2.9f)
        {
            countDown.text = "3";
        }
        if (counter < 2 && counter > 1.9f)
        {
            countDown.text = "2";
            Player1.gameObject.SetActive(true);
        }
        if (counter < 1 && counter > .9f)
        {
            countDown.text = "1";
            Player2.gameObject.SetActive(true);
        }
        if(counter < 0 && counter > -1)
        {
            countDown.text = "";
            Ball.gameObject.SetActive(true);
        }
        counter -= Time.deltaTime;
    }
    public void SetCountText()
    {
        Player1Score.text = player1ScoreDisplay.ToString();
        Player2Score.text = player2ScoreDisplay.ToString();
    }
}
