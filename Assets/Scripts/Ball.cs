using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Ball : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	    rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(rb);
            GetComponent<CircleCollider2D>().isTrigger = true;
            gameManager.inAir = false;
            //gameManager.disFromPaper.text = "" + Vector2.Distance(transform.position, gameManager.transform.position);
            gameManager.end();
        }

    }
}


