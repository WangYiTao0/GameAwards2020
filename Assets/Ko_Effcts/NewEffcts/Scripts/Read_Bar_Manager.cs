using Invector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Read_Bar_Manager : vMonoBehaviour
{
    [SerializeField] Image BackgroundBar;
    [SerializeField] Image ReadBar;
    [SerializeField] float m_Speed;
    [SerializeField] float m_Speed_fadout;
    [SerializeField] bool m_isSwitch;
    [SerializeField] bool m_isLife;
    //[SerializeField] GameObject Sound; 
    private float blend;
    // Start is called before the first frame update

    void Start()
    {
        m_isLife = true;
        m_isSwitch = true;
        ReadBar.fillAmount = 0.0f;
        blend = 1.0f;
    }

    private void FixedUpdate()
    {
        if(ReadBar.fillAmount<1.0f)
        {
            if(m_isSwitch)
            ReadBar.fillAmount += Time.deltaTime* m_Speed;
        }
       else if (ReadBar.fillAmount>=1.0f)
        {
            ReadBar.fillAmount = 1.0f;
            Action(true);
        }
        if (!m_isSwitch)
            Action(false);
    }
    void Action(bool UIswitch)
    {
        if (blend > 0.0f)
        {
            blend -= Time.deltaTime * m_Speed_fadout;
            BackgroundBar.color = new Color(1, 1, 1, blend);
            ReadBar.color = new Color(1, 1, 1, blend);
        }
        else
        {
            blend = 0.0f;
            Destroy(this.gameObject);
            m_isLife = false;
            if (UIswitch)
            {
              
                createSoundUI();
            }
        }

    }
    public void SetBarIsLife()
    {
        m_isLife = true;
        m_isSwitch = true;
    }
    public bool GetBarLifeorDie()
    {
        return m_isLife;
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F))
        {
            m_isSwitch = false;
        }
    }
    void createSoundUI()
    {
        //var Don = GameObject.Find("Effects_Sound_DonLoop").GetComponent<Effect_Don>();
        //if(Don.CanReceive)
        //{
        //    //a
        //    var AttackEffects = GameObject.Find("Player").transform.GetChild(2);
        //    var collision = AttackEffects.GetComponent<ParticleSystem>().collision;
        //    collision.enabled = true;
        //}
        GameObject.Find("vUI").transform.GetChild(1).GetChild(0).GetComponent<LunPanControl>().SoundMessageToLunpan();
        //Instantiate(Sound);

    }
}
