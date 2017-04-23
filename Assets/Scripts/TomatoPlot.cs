using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoPlot : DirtPlot {

    public Mesh tomato0;
    public float time1;
    public Mesh tomato1;
    public float time2;
    public Mesh tomato2;
    public float time3;
    public Mesh tomato3;

    private float nextGrow;
    private int stage;

    // Use this for initialization
    void Start () {
        salePrice = 0;
        waterDrain = 1f / 30f;
        water = 0.5f;
        type = 1;
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
                GetComponent<MeshRenderer>().material = selected ? highlightMaterial : defaultMaterial;
            }
        }

        if (Time.time > nextGrow)
        {
            if(stage == 0)
            {
                nextGrow += time2;
                GetComponent<MeshFilter>().mesh = tomato1;
                GetComponent<MeshCollider>().sharedMesh = tomato1;
                giveSeeds = 1;
                salePrice = 2;
            }
            if (stage == 1)
            {
                nextGrow += time3;
                GetComponent<MeshFilter>().mesh = tomato2;
                GetComponent<MeshCollider>().sharedMesh = tomato2;
                giveSeeds = 2;
                salePrice = 4;
            }
            if (stage == 2)
            {
                nextGrow += float.PositiveInfinity;
                GetComponent<MeshFilter>().mesh = tomato3;
                GetComponent<MeshCollider>().sharedMesh = tomato3;
                giveSeeds = 4;
                salePrice = 6;
            }

            stage++;
        }
	}
}
