using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnParticleCollision(GameObject other)
    {
        var Mode =
        GameObject.Find("Player").transform.GetChild(2).GetComponent<SoundAttcakControl>().GetCurrentMode();
        
        switch (Mode)
        {
            case SoundAttcakControl.ACTION_MODE.none:
                break;
            case SoundAttcakControl.ACTION_MODE.Don:
                this.gameObject.AddComponent<Rigidbody>();
                this.GetComponent<Rigidbody>().mass = 10000;
                break;
        }
    }
  
}
