using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class CMonoControy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] string MonoTagName;
    [SerializeField] float Distance;
    [SerializeField] float Speed;
     float rotation;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0;
        rotation = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        var Monos= GameObject.FindGameObjectsWithTag(MonoTagName);
        if(Monos!=null)
        {
            foreach (GameObject Mono in Monos)
            {
                var dist = Vector3.Distance(Mono.transform.position, this.transform.position);
                if (dist <= Distance)
                {
                    SetSpeed(Speed);
                    return;
                }
            }
        }
       

    }
 
    private void LateUpdate()
    {
        if(moveSpeed>0)
        {
            if (rotation >= 20.0f)
            {
                moveSpeed = 0;
                return;
            }
            {
                rotation += moveSpeed * Time.deltaTime;
                this.transform.localRotation = Quaternion.Euler(new Vector3(-27.106f - rotation, 0, 0));
            }

        }
    }
    public void SetSpeed(float x)
    {
        moveSpeed = x;
    }
    public void Updatecheck(GameObject obj)
    {
        var dist = Vector3.Distance(obj.transform.position, this.transform.position);
        if (dist <= Distance)
        {
            SetSpeed(Speed);
            return;
        }
    }
}
