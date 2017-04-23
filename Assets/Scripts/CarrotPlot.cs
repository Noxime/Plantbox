using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotPlot : DirtPlot {

    public Mesh carrot0;
    public float time1;
    public Mesh carrot1;
    public float time2;
    public Mesh carrot2;
    public float time3;
    public Mesh carrot3;

    public Material carrotLeaves;
    public Material carrotCarrot;

    private float nextGrow;
    private int stage;

    // Use this for initialization
    void Start () {
        salePrice = 1;
        waterDrain = 1f / 45f;
        water = 0.5f;
        type = 3;
        giveSeeds = 0;
        stage = 0;
        nextGrow = Time.time + time1;
	}

    

	// Update is called once per frame
	void Update () {

        water -= waterDrain * Time.deltaTime;
        
        if(water <= 0)
        {
            PlotManager.man.setPlot(transform, PlotManager.man.plantEmpty);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitinfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitinfo))
            {
                if (hitinfo.collider.gameObject == gameObject)
                {
                    selected = !selected;
                }

                
            }
        }

        Material[] mats = new Material[3];

        if (stage == 0)
        {
            mats[0] = defaultMaterial;
            mats[1] = carrotLeaves;
            mats[2] = carrotLeaves;
        }
        else
        {
            mats[0] = defaultMaterial;
            mats[1] = carrotCarrot;
            mats[2] = carrotLeaves;
        }

        mats[0] = selected ? highlightMaterial : defaultMaterial;
        GetComponent<MeshRenderer>().materials = mats;

        if (Time.time > nextGrow)
        {
            if(stage == 0)
            {
                nextGrow += time2;
                GetComponent<MeshFilter>().mesh = carrot1;
                GetComponent<MeshCollider>().sharedMesh = carrot1;
                giveSeeds = 1;
                salePrice = 2;
            }
            if (stage == 1)
            {
                nextGrow += time3;
                GetComponent<MeshFilter>().mesh = carrot2;
                GetComponent<MeshCollider>().sharedMesh = carrot2;
                giveSeeds = 2;
                salePrice = 3;
            }
            if (stage == 2)
            {
                nextGrow += float.PositiveInfinity;
                GetComponent<MeshFilter>().mesh = carrot3;
                GetComponent<MeshCollider>().sharedMesh = carrot3;
                giveSeeds = 3;
                salePrice = 4;
            }

            stage++;
        }
	}
}
