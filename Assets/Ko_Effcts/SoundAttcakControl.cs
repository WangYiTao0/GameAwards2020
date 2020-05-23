using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAttcakControl : MonoBehaviour
{
    public enum ACTION_MODE
    {
        none,
        Don,
    }
     [SerializeField] ACTION_MODE ActionMode;
     void Start()
    {
        this.GetComponent<ParticleSystem>().Stop();
        ActionMode = ACTION_MODE.none;
    }
    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetMouseButtonUp(0))
        {
            SoundAttackStop();
        }
    }
    void FixedUpdate()
    {
        
    }
    public void SoundAttackPlay()
    {
        this.GetComponent<ParticleSystem>().Play();
    }
    public void SoundAttackStop()
    {
        this.GetComponent<ParticleSystem>().Stop();
        ActionMode = ACTION_MODE.none;
    }
    public void SoundAttackCollisionEnabledSwitch()//粒子判定用
    {
        var collision = this.GetComponent<ParticleSystem>().collision;
        bool _bool = collision.enabled;
        collision.enabled = !_bool;
    }
    public ACTION_MODE  GetCurrentMode()
    {
        return ActionMode;
    }
    public void SetMode(ACTION_MODE mode)
    {
        ActionMode = mode;
    }
}
