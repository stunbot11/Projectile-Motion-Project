using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Numerics;
using System;

public class GameManager : MonoBehaviour
{
    public Launcher launcher;
    public GameObject paper;
    public GameObject endScreen;
    public Transform camStart;
    public GameObject paperPrefab;
    public CinemachineVirtualCamera vcam;
    public float minDis;
    public float maxDis;
    public float distance;


    public bool inAir;
    public float time;
    //settings
    public bool drag = true;
    public Slider angle;
    public TextMeshProUGUI angleTXT;
    public Slider velocity;
    public TextMeshProUGUI velocityTXT;
    public Slider height;
    public TextMeshProUGUI heightTXT;
    public TextMeshProUGUI dragTXT;
    public TextMeshProUGUI predction;
    private bool predic = false;


    //end screen
    public TextMeshProUGUI timeInAir;
    public TextMeshProUGUI totalDistance;
    public TextMeshProUGUI disFromPaper;
    public TextMeshProUGUI paperDis;
    public TextMeshProUGUI heighestPoint;
    public GameObject hitPaperScreen;

    private void Update()
    {
        if (inAir)
        {
            time += Time.deltaTime;
        }
        else if (!inAir && predic)
            predction.text = "Predicted distance: " + MathF.Round(Mathf.Sin(angle.value * Mathf.Deg2Rad) * velocity.value / 9.81f * 2 * (Mathf.Cos(angle.value * Mathf.Deg2Rad) * velocity.value), 2);
        else
            predction.text = "";

        heightTXT.text = "Height: " + MathF.Round(height.value, 2);
        angleTXT.text = "Angle: " + MathF.Round(angle.value, 2);
        velocityTXT.text = "Velocity: " + MathF.Round(velocity.value, 2);
    }

    public void end()
    {
        endScreen.SetActive(true);
        timeInAir.text = "Time in air: " + MathF.Round(time, 2);
        totalDistance.text = "Total distance: " + MathF.Round(distance, 2);
        if (paper != null)
            disFromPaper.text = "Distance from paper: " + MathF.Round(Mathf.Abs(paper.transform.position.x - distance), 2);
    }
    public void retry()
    {
        endScreen.SetActive(false);
        vcam.Follow = camStart;
        hitPaperScreen.SetActive(false);
    }

    public void generatePaper()
    {
        if(paper != null)
            Destroy(paper);
        paper = Instantiate(paperPrefab, null);
        paper.transform.SetPositionAndRotation(new UnityEngine.Vector3(Mathf.RoundToInt(UnityEngine.Random.Range(minDis, maxDis)), 0), UnityEngine.Quaternion.identity);
        paperDis.text = "Paper distance: " + paper.transform.position.x;
    }

    public void clearPaths()
    {
        GameObject[] toDestroy;
        toDestroy = GameObject.FindGameObjectsWithTag("ball");
        for (int i = 0; i < toDestroy.Length; i++)
        {
            Destroy(toDestroy[i]);
        }
    }

    public void showPrediction()
    {
        predic = predic ? false : true;
        
    }

    public void toggleDrag()
    {
        drag = (drag ? false : true);
        dragTXT.text = "Toggle Drag - " + (drag ? "On" : "Off");
    }
}
