using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WebManager : MonoBehaviour
{
    public PlanetManager PlanetManager;
    void Start()
    {
        StartCoroutine("LoadPlanet");
        StartCoroutine("AVGCollectors");
    }
    [SerializeField]
    List<Planet> _planetdata;
    public IEnumerator LoadPlanet()
    {
        _planetdata = new List<Planet>();
        WWW planetdata = new WWW("http://81.169.177.181/olp/planet_list.php");
        yield return planetdata;
        if (string.IsNullOrEmpty(planetdata.error))
        {
            _planetdata = new List<Planet>();
            _planetdata = JsonHelper.getJsonArray<Planet>(planetdata.text).ToList<Planet>();
            PlanetManager.AddPlanets(_planetdata);
        }
        else
        {
            Debug.LogError("ERROR FATAL");
        }
        _planetdata.Clear();
        PlanetManager.DrawPlanets();

    }

    public IEnumerator AVGCollectors()
    {

        //Login to the website and wait for a response
        WWW w = new WWW("http://81.169.177.181/OLP/avg_data.php");
        yield return w;

        //Check if the response if empty or not
        if (string.IsNullOrEmpty(w.error))
        {
            //Return the json array and put it in the C# AverageData class
            Averagedata avgdata = JsonUtility.FromJson<Averagedata>(w.text);
            if (avgdata.success == true)
            {
                //Check if there is any error in the class. If there is return the error
                if (avgdata.error != "")
                {
                    Debug.Log("avg.error");
                }
                else
                {
                    PlanetManager.SetAVG(avgdata);
                    PlanetManager.InitMainPlanet();
                    Debug.Log("average data imported successful.");
                }
                //If the JsonArary is empty return this string in the feedback
            }
            else
            {
                Debug.Log("An error occured.");
            }

            //If the string is empty return this string in the feedback
        }
        else
        {
            // error
            Debug.Log( "An error occured.");
        }

    }
}