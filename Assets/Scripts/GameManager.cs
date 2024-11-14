using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject paper;
    public GameObject endScreen;

    public bool inAir;
    public float time;
    //settings
    public Slider angle;
    public TextMeshProUGUI angleTXT;
    public Slider velocity;
    public TextMeshProUGUI velocityTXT;

    //end screen
    public TextMeshProUGUI timeInAir;
    public TextMeshProUGUI totalDistance;
    public TextMeshProUGUI disFromPaper;

    private void Update()
    {
        if (inAir)
	    {
		time += Time.deltaTime;
	    }

        angleTXT.text = "Angle: " + angle.value;
        velocityTXT.text = "Velocity: " + velocity.value;
    }

    public void end()
    {
        endScreen.SetActive(true);
    }

}
