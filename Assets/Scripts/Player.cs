using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float coinWeight = 0.2f;

    private CharacterController2D _controller;
    private NonPhysicsMovement _movement;
    private int coins = 0;
    private float maxJump;

	// Use this for initialization
	void Awake () {
        _controller = GetComponent<CharacterController2D>();
        _controller.onTriggerEnterEvent += onTriggerEnterEvent;
        _controller.onTriggerExitEvent += onTriggerExitEvent;
        _movement = GetComponent<NonPhysicsMovement>();
        maxJump = _movement.jumpHeight;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onTriggerEnterEvent(Collider2D col)
    {
        Collectible coin = col.GetComponent<Collectible>();
        if (coin != null)
        {
            updateCoins(1);
            coin.pickup();
        }

        BasicEnemy enemy = col.GetComponent<BasicEnemy>();
        if (enemy != null)
        {
            updateCoins(-3);
            coin.pickup();
        }

        Debug.Log("onTriggerEnterEvent: " + col.gameObject.name);
    }


    void onTriggerExitEvent(Collider2D col)
    {
        Debug.Log("onTriggerExitEvent: " + col.gameObject.name);
    }

    void updateCoins(int amount) {
        coins += amount;
        if (coins < 0) coins = 0;
        _movement.jumpHeight = Mathf.Max(maxJump - (coins * coinWeight), 0);
        
    }

    public int getCoins()
    {
        return coins;
    }
}
