using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;
    public CinemachineVirtualCamera vcam;
    public GameObject ball;
    public Transform shotPos;
    public Slider heightS;


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
        transform.position = new Vector3(0, heightS.value, 0);
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
        p.GetComponent<Rigidbody2D>().drag = gameManager.drag ? .3f : 0;
        p.GetComponent<Rigidbody2D>().velocity = vel;
        vcam.Follow = p.transform;
    }
}
