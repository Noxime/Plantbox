using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionLoader : MonoBehaviour {

    public static int starterCash = 0;
    public static int starterTS = 0;
    public static int starterCuS = 0;
    public static int starterCaS = 0;

    public static int goalCash = 0;
    public static int goalTS = 0;
    public static int goalCuS = 0;
    public static int goalCaS = 0;

    public static bool sandboxMode = false;

    public void load1()
    {
        starterCash = 10;
        starterTS = 2;
        starterCuS = 0;
        starterCaS = 0;

        goalCash = 0;
        goalTS = 5;
        goalCuS = 0;
        goalCaS = 0;

        sandboxMode = false;

        Application.LoadLevel(1);
        
    }
    public void load2()
    {
        starterCash = 10;
        starterTS = 1;
        starterCuS = 2;
        starterCaS = 0;

        goalCash = 5;
        goalTS = 2;
        goalCuS = 3;
        goalCaS = 0;

        sandboxMode = false;

        Application.LoadLevel(1);

    }
    public void load3()
    {
        starterCash = 20;
        starterTS = 2;
        starterCuS = 2;
        starterCaS = 3;

        goalCash = 5;
        goalTS = 8;
        goalCuS = 5;
        goalCaS = 4;

        sandboxMode = false;

        Application.LoadLevel(1);

    }
    public void load4()
    {
        starterCash = 50;
        starterTS = 10;
        starterCuS = 5;
        starterCaS = 2;

        goalCash = 50;
        goalTS = 10;
        goalCuS = 10;
        goalCaS = 10;

        sandboxMode = false;

        Application.LoadLevel(1);

    }

    public void loadMenu()
    {
        Application.LoadLevel(0);
    }

    public void loadS()
    {
        starterCash = 0;
        starterTS   = 0;
        starterCuS  = 0;
        starterCaS  = 0;

        goalCash = 0;
        goalTS   = 0;
        goalCuS  = 0;
        goalCaS  = 0;

        sandboxMode = true;

        Application.LoadLevel(1);

    }

    
}
