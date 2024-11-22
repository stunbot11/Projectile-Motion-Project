using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;

    private float height;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	    rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (height <= transform.position.y && gameManager.inAir)
        {
            height = transform.position.y;
            gameManager.heighestPoint.text = "Max Height: " + MathF.Round(height, 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(rb);
            GetComponent<CircleCollider2D>().isTrigger = true;
            gameManager.inAir = false;
            gameManager.distance = transform.position.x;
            gameManager.end();
            if (Mathf.Abs(transform.position.x - gameManager.paper.transform.position.x) <= 5)
                gameManager.hitPaperScreen.SetActive(true);
        }

    }
}


