using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CActionEventsManager : MonoBehaviour
{
    public Animator myanimator;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
        }
    }
    public void OnPickupMonoStart()
    {

    }
    public void OnPickupMonoEnd()
    {
        GameObject.Find("vUI").transform.GetChild(1).GetChild(0).GetComponent<LunPanControl>().SoundMessageToLunpan();
    }
}
