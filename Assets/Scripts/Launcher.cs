using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;
    public GameObject ball;
    public Transform shotPos;

    public float height;
    public float angle;
    public float velocity;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        angle = gameManager.angle.value;
        velocity = gameManager.velocity.value;
        Mathf.Clamp(angle, 0, 90);
        rb.rotation = angle;
    }

    public void shoot()
    {
        Vector2 vel = new Vector2(MathF.Cos(angle * Mathf.Deg2Rad) * velocity, MathF.Sin(angle * Mathf.Deg2Rad) * velocity);
        gameManager.time = 0;
        gameManager.inAir = true;
        GameObject p = Instantiate(ball, shotPos.position, Quaternion.identity);
        p.GetComponent<Rigidbody2D>().AddForce(vel);
    }
}
