using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberPlot : DirtPlot {

    public Mesh cucumber0;
    public float time1;
    public Mesh cucumber1;
    public float time2;
    public Mesh cucumber2;
    public float time3;
    public Mesh cucumber3;

    private float nextGrow;
    private int stage;

    // Use this for initialization
    void Start () {
        salePrice = 0;
        waterDrain = 1f / 30f;
        water = 0.5f;
        type = 2;
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
                Material[] mats = GetComponent<MeshRenderer>().materials;
                mats[1] = selected ? highlightMaterial : defaultMaterial;
                GetComponent<MeshRenderer>().materials = mats;
            }
        }

        if (Time.time > nextGrow)
        {
            if(stage == 0)
            {
                nextGrow += time2;
                GetComponent<MeshFilter>().mesh = cucumber1;
                GetComponent<MeshCollider>().sharedMesh = cucumber1;
                giveSeeds = 1;
                salePrice = 1;
            }
            if (stage == 1)
            {
                nextGrow += time3;
                GetComponent<MeshFilter>().mesh = cucumber2;
                GetComponent<MeshCollider>().sharedMesh = cucumber2;
                giveSeeds = 2;
                salePrice = 3;
            }
            if (stage == 2)
            {
                nextGrow += float.PositiveInfinity;
                GetComponent<MeshFilter>().mesh = cucumber3;
                GetComponent<MeshCollider>().sharedMesh = cucumber3;
                giveSeeds = 4;
                salePrice = 4;
            }

            stage++;
        }
	}
}
