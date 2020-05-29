using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunPanManger : MonoBehaviour
{
    [SerializeField] GameObject LunPan;
    [SerializeField] GameObject Presstarget;
    // Start is called before the first frame update
    void Start()
    {
        LunpanOff();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            LunpanOn();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            LunpanOn();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LunpanOn();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LunpanOn();
        }
  
    }
    public void LunpanOn()
    {
        LunPan.SetActive(true);
        Presstarget.SetActive(true);
    }
    public void LunpanOff()
    {
        LunPan.SetActive(false);
        Presstarget.SetActive(false);
    }
}
