using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Read_Bar_Manager : MonoBehaviour
{
    [SerializeField] Image BackgroundBar;
    [SerializeField] Image ReadBar;
    [SerializeField] float m_Speed;
    [SerializeField] float m_Speed_fadout;
    private float blend;
    // Start is called before the first frame update

    void Start()
    {
        ReadBar.fillAmount = 0.0f;
        blend = 1.0f;
    }

    private void FixedUpdate()
    {
        if(ReadBar.fillAmount<1.0f)
        {
            ReadBar.fillAmount += Time.deltaTime* m_Speed;
        }
        else
        {
            ReadBar.fillAmount = 1.0f;
            Action();
        }
    }
    void Action()
    {
        if (blend > 0.0f)
        {
            blend -= Time.deltaTime * m_Speed_fadout;
<<<<<<< HEAD
            Debug.Log(blend);
=======
>>>>>>> 640b5b4... Merge pull request #5 from WangYiTao0/feature/胡俊林FirstBlood
            BackgroundBar.color = new Color(1, 1, 1, blend);
            ReadBar.color = new Color(1, 1, 1, blend);
        }
        else
        {
            blend = 0.0f;
            Destroy(this.gameObject);
        }
     
    }
}
