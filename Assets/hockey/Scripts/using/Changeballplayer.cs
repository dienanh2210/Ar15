using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeballplayer : MonoBehaviour {

    public GameObject ball;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void changeBall() {
        ball.SetActive(true);
        player.SetActive(false);
    }
    public void changPlayer() {
        player.SetActive(true);
        ball.SetActive(false);
    }
}
