using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 struct Day
{
    public float Intensity;
    public Vector3 Pos;
}
 struct DayNight
{
    public float Intensity;
    public Vector3 Pos;
}
public class SunControl : MonoBehaviour
{
    [SerializeField] GameObject SunOne;
    [SerializeField] GameObject SunTwo;
    [SerializeField] bool Isnight;
    [SerializeField] Day day;
    [SerializeField] DayNight daynight;
    // Start is called before the first frame update
    void Start()
    {
        Isnight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Isnight)
        {
            SunOne.GetComponent<Light>().intensity = daynight.Intensity;
            SunOne.GetComponent<Transform>().localPosition = daynight.Pos;
            SunTwo.GetComponent<Light>().intensity = daynight.Intensity;
            SunTwo.GetComponent<Transform>().localPosition = daynight.Pos;
        }
        else
        {
            SunOne.GetComponent<Light>().intensity = day.Intensity;
            SunOne.GetComponent<Transform>().localPosition = day.Pos;
            SunTwo.GetComponent<Light>().intensity = day.Intensity;
        }
    }
}
