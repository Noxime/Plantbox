using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionTooltips : MonoBehaviour {

    public void resetTooltip()
    {
        GetComponent<Text>().text = "Welcome to plantbox, your favorite plant watering simulator!\n\nGo ahead and select your mission or head over to the sandbox mode!";
    }

    public void tooltip1()
    {
        GetComponent<Text>().text = "Start with $10 and 2 tomato seeds.\n\nGet up to 5 tomato seeds.";
    }
    public void tooltip2()
    {
        GetComponent<Text>().text = "Start with $10, 1 tomato and 2 cucumber seeds.\n\nReach $5, 2 tomato seeds and 3 cucumber seeds.";
    }
    public void tooltip3()
    {
        GetComponent<Text>().text = "Start with $20, 2 tomato and cucumber seeds, and 3 carrot seeds.\n\nGet up to $5, 8 tomato seeds, 5 cucumber seeds and 4 carrot seeds.";
    }
    public void tooltip4()
    {
        GetComponent<Text>().text = "Start with $50, 10 tomato seeds, 5 cucumber seeds and 2 carrot seeds.\n\nGoal is $50, 10 tomato, cucumber and carrot seeds.";
    }

    public void tooltipSandbox()
    {
        GetComponent<Text>().text = "No goals, no limits. Go nuts!";
    }
}
