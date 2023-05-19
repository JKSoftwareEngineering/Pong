using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public Light player_1;
    public Light player_2;
    public GameObject player;
    public GameObject playerLowCollider;
    public GameObject bottomWall;
    public GameObject OldPlayer;
    public GameObject ball;

    private float bottomRange;
    private float bottomOfPLowCollide;
    private float yScalePLowCollider;
    private bool controler;

    // Start is called before the first frame update
    void Start()
    {
        controler = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(controler)
        {
            player_1.intensity = 20;
            player_2.intensity = 20;
            bottomRange = bottomWall.transform.position.y + (bottomWall.transform.localScale.y / 2) + 0.5f;
            yScalePLowCollider = playerLowCollider.transform.localScale.y / 2;
            player.transform.position = new Vector3(OldPlayer.transform.position.x, OldPlayer.transform.position.y, OldPlayer.transform.position.z);
            transform.localScale = new Vector3(OldPlayer.transform.localScale.x, OldPlayer.transform.localScale.y, OldPlayer.transform.localScale.z);
            OldPlayer.gameObject.SetActive(false);
            ball.gameObject.SetActive(false);
            controler = false;
        }
        bottomOfPLowCollide = playerLowCollider.transform.position.y - yScalePLowCollider;
        if (bottomOfPLowCollide > bottomRange)
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y - 1 * Time.deltaTime, transform.position.z);
        }
        if(player_1.intensity > 0.0f)
        {
            player_1.intensity -= 0.5f;
            player_2.intensity -= 0.5f;
        }
    }
}
