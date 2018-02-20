using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlanetData : MonoBehaviour {

    [Header("Planet Data")]
    public Planet Planet;

    [Header("UI Components")]
    public Text Name;
    public Text PopulationText;
    public Text CurrencyText;
    public Text EnvironmentText;
    public Text HappinessText;


    public void LoadData()
    {
        Name.text = "Planet from " + Planet.name;
        PopulationText.text = "Population of: " + Planet.population;
        CurrencyText.text = "P: " + Planet.currency;
        EnvironmentText.text = "Health of planet " + Planet.environment + "%";
        HappinessText.text = "Happiness " + Planet.happiness + "%";
        GraphicData();
    }

    private void GraphicData()
    {
        if(Planet.environment < 40)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (Planet.environment > 70)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if(Planet.environment < 70  && Planet.environment > 40)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
