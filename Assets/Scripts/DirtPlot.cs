using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPlot : MonoBehaviour {

    
    public Material highlightMaterial;
    public Material defaultMaterial;
    public bool selected = false;
    public int type;
    public int giveSeeds;
    public float water;
    public float waterDrain;
    public int salePrice;

    // Use this for initialization
    void Start () {
        salePrice = 0;
        waterDrain = 0;
        water = 0;
        type = 0;
        giveSeeds = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitinfo;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitinfo))
            {
                if (hitinfo.collider.gameObject == gameObject)
                {
                    selected = !selected;
                }
                GetComponent<MeshRenderer>().material = selected ? highlightMaterial : defaultMaterial;
            }
        }
	}
}
