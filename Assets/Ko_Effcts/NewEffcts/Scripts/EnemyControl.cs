using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] GameObject targetmono;
    [SerializeField] float m_smoothTime;
    [SerializeField] float distance;
    Vector3 m_speed = Vector3.zero;

    bool followSwitch;

    // Start is called before the first frame update
    void Start()
    {
        followSwitch = false;

    }

    // Update is called once per frame
    void Update()
    {
        var pos =
        GameObject.Find("Player").GetComponent<Transform>().position;
        float dis = Vector3.Distance(pos, transform.position);
        if (dis <= distance) followSwitch = true;
    }
    private void FixedUpdate()
    {
        if(followSwitch)
        transform.position = Vector3.SmoothDamp(transform.position, targetmono.GetComponent<Transform>().position, ref m_speed, m_smoothTime);
    }
    public void SetTarget(GameObject target)
    {
        targetmono = target;
    }
}
