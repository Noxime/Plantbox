using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour {

    public static PlotManager man;

    public static int cash = 25;

    public static int wateringPrice = 1;

    public static int tomatoSeeds = 2;
    public static int cucumberSeeds = 3;
    public static int carrotSeeds = 3;

    public Transform waterIndicator;

    public Transform menuButton;

    public Transform plantEmpty;
    public Transform plantTomato;
    public Transform plantCucumber;
    public Transform plantCarrot;
    public int priceTomato = 5;
    public int priceCucumber = 2;
    public int priceCarrot = 2;
    public Transform[][] plots;
    public Transform[][] indicators;

	// Use this for initialization
	void Start () {
        cash = MissionLoader.starterCash;
        tomatoSeeds = MissionLoader.starterTS;
        cucumberSeeds = MissionLoader.starterCuS;
        carrotSeeds = MissionLoader.starterCaS;

        man = this;
        plots = new Transform[5][];
        indicators = new Transform[5][];

		for(int x = -2; x <= 2; x++)
        {
            plots[x + 2] = new Transform[3];
            indicators[x + 2] = new Transform[3];
            for(int z = -1; z <= 1; z++)
            {
                plots[x + 2][z + 1] = Instantiate(plantEmpty, new Vector3(x, 0.9f, z + 0.5f), Quaternion.Euler(-90, 0, 0));
                indicators[x + 2][z + 1] = Instantiate(waterIndicator, new Vector3(x + 0.375f, 0.9f, z + 0.125f), Quaternion.identity);
            }
        }
	}
	
    public void setPlot(Transform old, Transform plant)
    {
        for (int x = -2; x <= 2; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                if (plots[x + 2][z + 1] == old)
                {
                    Destroy(plots[x + 2][z + 1].gameObject);
                    plots[x + 2][z + 1] = Instantiate(plant, new Vector3(x, 0.9f, z + 0.5f), Quaternion.Euler(-90, 0, 0));
                }
            }
        }
                    
        
    }
    
    public void purchaseTomatoes()
    {
        int price = 0;
        int seeds = 0;

        for (int x = -2; x <= 2; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                if (plots[x + 2][z + 1].GetComponent<DirtPlot>().selected)
                {
                    price += priceTomato;
                    seeds++;
                }
            }
        }

        if (MissionLoader.sandboxMode)
        {
            price = 0;
            seeds = 0;
        }

            if (price <= cash && seeds <= tomatoSeeds)
        {
            for (int x = -2; x <= 2; x++)
            {
                for (int z = -1; z <= 1; z++)
                {

                    if (plots[x + 2][z + 1].GetComponent<DirtPlot>().selected)
                    {
                        Destroy(plots[x + 2][z + 1].gameObject);
                        plots[x + 2][z + 1] = Instantiate(plantTomato, new Vector3(x, 0.9f, z + 0.5f), Quaternion.Euler(-90, 0, 0));
                        if (!MissionLoader.sandboxMode) cash -= priceTomato;
                        if (!MissionLoader.sandboxMode) tomatoSeeds--;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Could not afford tomatoes");
        }
    }

    public void purchaseCucumbers()
    {
        int price = 0;
        int seeds = 0;

        for (int x = -2; x <= 2; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                if (plots[x + 2][z + 1].GetComponent<DirtPlot>().selected)
                {
                    price += priceCucumber;
                    seeds++;
                }
            }
        }

        if (MissionLoader.sandboxMode)
        {
            price = 0;
            seeds = 0;
        }

            if (price <= cash && seeds <= cucumberSeeds)
        {
            for (int x = -2; x <= 2; x++)
            {
                for (int z = -1; z <= 1; z++)
                {

                    if (plots[x + 2][z + 1].GetComponent<DirtPlot>().selected)
                    {
                        Destroy(plots[x + 2][z + 1].gameObject);
                        plots[x + 2][z + 1] = Instantiate(plantCucumber, new Vector3(x, 0.9f, z + 0.5f), Quaternion.Euler(-90, 0, 0));
                        if (!MissionLoader.sandboxMode) cash -= priceCucumber;
                        if (!MissionLoader.sandboxMode) cucumberSeeds--;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Could not afford cucumbers");
        }
    }

    public void purchaseCarrots()
    {
        int price = 0;
        int seeds = 0;

        for (int x = -2; x <= 2; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                if (plots[x + 2][z + 1].GetComponent<DirtPlot>().selected)
                {
                    price += priceCarrot;
                    seeds++;
                }
            }
        }

        if (MissionLoader.sandboxMode)
        {
            price = 0;
            seeds = 0;
        }

        if (price <= cash && seeds <= carrotSeeds)
        {
            for (int x = -2; x <= 2; x++)
            {
                for (int z = -1; z <= 1; z++)
                {

                    if (plots[x + 2][z + 1].GetComponent<DirtPlot>().selected)
                    {
                        Destroy(plots[x + 2][z + 1].gameObject);
                        plots[x + 2][z + 1] = Instantiate(plantCarrot, new Vector3(x, 0.9f, z + 0.5f), Quaternion.Euler(-90, 0, 0));
                        if (!MissionLoader.sandboxMode) cash -= priceCarrot;
                        if (!MissionLoader.sandboxMode) carrotSeeds--;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Could not afford carrots");
        }
    }


    public void harvestSeeds()
    {

        for (int x = -2; x <= 2; x++)
        {
            for (int z = -1; z <= 1; z++)
            {

                if (plots[x + 2][z + 1].GetComponent<DirtPlot>().selected)
                {

                    if (plots[x + 2][z + 1].GetComponent<DirtPlot>().type == 1)
                    {
                        //Tomato plant found
                        tomatoSeeds += plots[x + 2][z + 1].GetComponent<DirtPlot>().giveSeeds;
                    }
                    if (plots[x + 2][z + 1].GetComponent<DirtPlot>().type == 2)
                    {
                        //Cucumber plant found
                        cucumberSeeds += plots[x + 2][z + 1].GetComponent<DirtPlot>().giveSeeds;
                    }

                    if (plots[x + 2][z + 1].GetComponent<DirtPlot>().type == 3)
                    {
                        //Carrot plant found
                        carrotSeeds += plots[x + 2][z + 1].GetComponent<DirtPlot>().giveSeeds;
                    }

                    Destroy(plots[x + 2][z + 1].gameObject);
                    plots[x + 2][z + 1] = Instantiate(plantEmpty, new Vector3(x, 0.9f, z + 0.5f), Quaternion.Euler(-90, 0, 0));
                    
                }
            }
        }
    }

    public void waterPlants()
    {

        int price = 0;

        for (int x = -2; x <= 2; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                if (plots[x + 2][z + 1].GetComponent<DirtPlot>().selected)
                {
                    price += wateringPrice;
                }
            }
        }

        if(MissionLoader.sandboxMode)
        {
            price = 0;
        }

        if (price <= cash)
        {
            for (int x = -2; x <= 2; x++)
            {
                for (int z = -1; z <= 1; z++)
                {

                    if (plots[x + 2][z + 1].GetComponent<DirtPlot>().selected)
                    {
                        plots[x + 2][z + 1].GetComponent<DirtPlot>().water = 1;
                        if(!MissionLoader.sandboxMode) cash -= wateringPrice;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Could not afford to water plants");
        }
    }

    public void sellPlants()
    {
        for (int x = -2; x <= 2; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                if (plots[x + 2][z + 1].GetComponent<DirtPlot>().selected)
                {
                    cash += plots[x + 2][z + 1].GetComponent<DirtPlot>().salePrice;

                    Destroy(plots[x + 2][z + 1].gameObject);
                    plots[x + 2][z + 1] = Instantiate(plantEmpty, new Vector3(x, 0.9f, z + 0.5f), Quaternion.Euler(-90, 0, 0));
                }
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(!MissionLoader.sandboxMode)
        {
            if (cash >= MissionLoader.goalCash)
            {
                if (tomatoSeeds >= MissionLoader.goalTS)
                {
                    if (cucumberSeeds >= MissionLoader.goalCuS)
                    {
                        if (carrotSeeds >= MissionLoader.goalCaS)
                        {
                            Debug.Log("Mission complete");
                            menuButton.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
        

        for (int x = -2; x <= 2; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                indicators[x + 2][z + 1].GetChild(0).transform.localScale = new Vector3(1, plots[x + 2][z + 1].GetComponent<DirtPlot>().water, 1);
            }
        }

        GameObject.Find("CashCounter").GetComponent<Text>().text = "Cash: $" + cash;
        GameObject.Find("TomatoSeedCounter").GetComponent<Text>().text = "Tomato seeds: " + tomatoSeeds;
        GameObject.Find("CucumberSeedCounter").GetComponent<Text>().text = "Cucumber seeds: " + cucumberSeeds;
        GameObject.Find("CarrotSeedCounter").GetComponent<Text>().text = "Carrot seeds: " + carrotSeeds;
    }
}
