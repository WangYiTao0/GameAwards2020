using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsFadeinout : MonoBehaviour
{
    [SerializeField] private Image mImage;
    [SerializeField] private float mLifeTimer;
    [SerializeField] private float mSpeed;
    private float mBlend;
    private bool FadeControl;
    // Start is called before the first frame update
    void Start()
    {
        mBlend = 0.0f;
        FadeControl = false;
        mImage.color = new Color(1, 1, 1, 0);
    }

        
    private void FixedUpdate()
    {
        if (!FadeControl)
        {
            mImage.color = new Color(1, 1, 1, mBlend);
            if (mBlend < 1.0f)
            {
                mBlend += Time.deltaTime + mSpeed/1000;
            }
            else
            {
                mBlend = 1.0f;
                FadeControl = true;
            }
        }
        else
        {
            if (mLifeTimer > 0.0f)
            {
                mLifeTimer -= Time.deltaTime;
            }
            else
            {
                mImage.color = new Color(1, 1, 1, mBlend);
                if (mBlend > 0.0f)
                {
                    mBlend -= Time.deltaTime * mSpeed;
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
