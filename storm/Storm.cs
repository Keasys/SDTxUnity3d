using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : Singleton<Storm>
{

    protected Storm() { }

    private System.Random rand = new System.Random();
    public double windSpeed, karmanDiameter, cavityLength, cavityDiameter, radius, depth=1, riseFactor;

    public int maxDelay;

    public static void nextRainDrop()
    {
        Instance.radius = Instance.rand.NextDouble()*0.0085 + 0.0015  ;
        Instance.riseFactor = Instance.rand.NextDouble()*0.4 + 0.2;
        //Debug.Log("Radius: "+Instance.radius+" riseFactor: "+Instance.riseFactor);
    }

    public void Update()
    {
        
    }

}
