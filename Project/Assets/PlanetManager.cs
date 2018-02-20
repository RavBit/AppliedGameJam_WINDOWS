using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetManager : MonoBehaviour {
    public List<Planet> Planets;
    public GameObject PlanetPrefab;

    public GameObject MainPlanet;

    [SerializeField]
    public Averagedata AverageData;
	// Use this for initialization
	void Start () {
        Planets = new List<Planet>();
	}

    public void AddPlanets(List<Planet> _planetlist)
    {
        Planets = _planetlist.ToList<Planet>();
    }
    public void SetAVG(Averagedata avg)
    {
        AverageData = avg;
    }
    public void DrawPlanets()
    {
        for (int i = 0; i < Planets.Count; i++)
        {
            GameObject planet = Instantiate(PlanetPrefab, new Vector3(3 * i, 0, 0), Quaternion.identity) as GameObject;
            planet.GetComponent<PlanetData>().Planet = Planets[i];
            planet.GetComponent<PlanetData>().LoadData();
        }
    }

    public void InitMainPlanet()
    {
        Planet mainplanet = new Planet();
        mainplanet.name = "The Main Planet";
        mainplanet.currency = AverageData.currency;
        mainplanet.environment = AverageData.environment;
        mainplanet.population = AverageData.population;
        mainplanet.happiness = AverageData.happiness;
        MainPlanet.GetComponent<PlanetData>().Planet = mainplanet;
        MainPlanet.GetComponent<PlanetData>().LoadData();
    }
}
