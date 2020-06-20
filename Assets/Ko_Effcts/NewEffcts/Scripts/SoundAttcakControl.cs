using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SoundAttcakControl : MonoBehaviour
{
    public enum ACTION_MODE
    {
        none,
        Don,
        type0,
        type1,
        type2,
        type3,
    }
     [SerializeField] ACTION_MODE ActionMode;
    [SerializeField] float MoveSpeed;
    [SerializeField] float CountDowntimer;
    [SerializeField] float HightSize;
    private float Currenttime;
    private Vector3 MoveDir;
    [SerializeField] GameObject Player;
     void Start()
    {
        this.GetComponent<ParticleSystem>().Stop();
        ActionMode = ACTION_MODE.none;
        Currenttime = 0;
    }
    // Update is called once per frame
    void Update()
    {
    
        //if (Input.GetMouseButtonUp(0))
        //{
        //    SoundAttackStop();
        //}
    }
    void FixedUpdate()
    {
        if (Currenttime < CountDowntimer)
        {
            transform.position += MoveDir * MoveSpeed*Time.deltaTime;
            Currenttime += Time.deltaTime;
        }
        else
        {
            SoundAttackStop();
            this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 300, Player.transform.position.z);
        }
    }
    public void SoundAttackPlay()
    {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y+HightSize, Player.transform.position.z);
        this.GetComponent<ParticleSystem>().Play();
        this.transform.SetParent(Player.transform.parent.transform);
        this.transform.forward = Player.transform.forward;
        MoveDir = Player.transform.forward;
        Currenttime = 0.0f;
    }
    public void SoundAttackStop()
    {
        this.GetComponent<ParticleSystem>().Stop();
        ActionMode = ACTION_MODE.none;
        this.transform.SetParent(Player.transform);
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
