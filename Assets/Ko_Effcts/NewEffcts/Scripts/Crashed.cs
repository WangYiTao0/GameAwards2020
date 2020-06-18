using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Crashed : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public GameObject objcrasjed;
    [SerializeField] GameObject mAttack;

    void Start()
    {

    }

    // Update is called once per frame
  
  
    private void OnParticleCollision(GameObject other)
    {
        var Mode =
        mAttack.GetComponent<SoundAttcakControl>().GetCurrentMode();

        switch (Mode)
        {
            case SoundAttcakControl.ACTION_MODE.none:
                break;
            case SoundAttcakControl.ACTION_MODE.Don:
                if (other.tag == "AttackAction")//collide with particles
                {
                    var obj2 =
             Instantiate(objcrasjed, obj.transform.position, obj.transform.rotation);
                    obj2.gameObject.transform.localScale = this.transform.parent.parent.lossyScale;
                    Destroy(obj);
                }
                break;
        }
    }
}
