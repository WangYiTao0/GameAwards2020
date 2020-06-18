using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LunPanControl : SoundtypeManager
{
    public GameObject LunPan;
    [SerializeField] GameObject PressPos;// 按下的位置
    [SerializeField] float Speed; //旋转速度
    [SerializeField] float recoilSpeed;//后坐力速度
    [SerializeField] List<GameObject> SoundUI;//轮盘管理
    [SerializeField] List<Sprite> SoundImage;
    [SerializeField] List<SOUND_TYPE> SoundKnapsack;
    [SerializeField] Sprite NoneImage;
    float CurrentrotAngle;
    float nextAngle;
    float CountState;


     void Start()
    {
        //SoundUI[1].GetComponent<Button>().onClick.AddListener(asdssssss);
      
        CurrentrotAngle = 0;
        nextAngle = 0;
        CountState = 10;
        LunPanInit();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //滑轮移动处理
            if (nextAngle == 0)
                CountState = 0;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (nextAngle == 0)
                CountState = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(nextAngle==0)
               CountState = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (nextAngle == 0)
                CountState = 1;
            
        }
        LunPanColorControl();//轮盘颜色管理
        if (Input.GetMouseButtonDown(0))//点击UI
        {
            ClickLunPan();//点击轮盘中的UI
            this.transform.GetComponentInParent<LunPanManger>().LunpanOff();
            //var ReleaseSound =
            //GameObject.Find("Player").transform.GetChild(2).GetComponent<SoundAttcakControl>();
            //ReleaseSound.SoundAttackPlay();
        }




    }
    void FixedUpdate()
    {
        LunPanRun();
    }
    void LunPanInit()
    {
        for (int i = 0; i < 4; i++)
        {
            SoundUI[i].GetComponent<Image>().sprite = NoneImage;
        }
    }
    public void LunPanRun()
    {
       
        switch (CountState)
        {
            case 0:
                //if (CurrentrotAngle < 270)
                {
                    LunPan.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, CurrentrotAngle + nextAngle));

                    nextAngle += Time.deltaTime * Speed;

                    if (nextAngle >= 90+recoilSpeed)
                    {
                        CurrentrotAngle = CurrentrotAngle + 90;
                        CountState = 10;
                        nextAngle = 0;
                    }
                }
              
                break;
            case 1:
                //if (CurrentrotAngle >= -270)
                {
                    LunPan.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, CurrentrotAngle - nextAngle));

                    nextAngle += Time.deltaTime * Speed;

                    if (nextAngle >= 90 + recoilSpeed)
                    {
                        CurrentrotAngle = CurrentrotAngle - 90;
                        CountState = 10;
                        nextAngle = 0;
                    }
                }
                break;
            default:
                LunPan.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, CurrentrotAngle));
                break;
        }


    }
    private void AddonClickEnvent(int num, UnityEngine.Events.UnityAction Name)
    {
            SoundUI[num].GetComponent<Button>().onClick.AddListener(Name);
    }
    private void RemoveSoundForLunPan(int num)
    {
        for (int i = 0; i < SoundUI.Count; i++)
        {
            if (i == num)
                SoundUI[i].GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
    public void RemoveSoundForKnapsack(int num)
    {
        for (int i = 0; i < SoundKnapsack.Count; i++)
        {
            if (SoundKnapsack[i].SoundID == num)
                SoundKnapsack.RemoveAt(i);
        }

    }
    private void ChangeImage(int num,Sprite _Sprite)
    {
        SoundUI[num].GetComponent<Image>().sprite = _Sprite;
    }
    public void ClickLunPan()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector2 pos = SoundUI[i].GetComponent<Transform>().position;
            Vector2 targetPos = PressPos.GetComponent<Transform>().position;
            float distans = Vector2.Distance(pos, targetPos);
            if (distans < 30)
            {
                if (SoundUI[i].GetComponent<Image>().sprite != NoneImage)
                {
                    SoundUI[i].GetComponent<Button>().onClick.Invoke();
                    RemoveSoundForLunPan(i);
                    ChangeImage(i, NoneImage);
                }
                //RemoveClickEnvent();
            }
        }
    }
    public void LunPanColorControl()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector2 pos = SoundUI[i].GetComponent<Transform>().position;
            Vector2 targetPos = PressPos.GetComponent<Transform>().position;
            float distans = Vector2.Distance(pos, targetPos);
            SoundUI[i].GetComponent<Image>().color= new Color(1, 1, 1, 0.1f);
            if (distans < 30)
            {
                SoundUI[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                //RemoveClickEnvent();
            }
        }
    }
    public void AddSoundToKnapsack(SOUND_TYPE _soundmessge)
    {
        for (int i = 0; i < SoundKnapsack.Count; i++)
        {
            if (SoundKnapsack[i].SoundID == _soundmessge.SoundID) return;
        }
        SoundKnapsack.Add(_soundmessge);

    }
    public void SoundMessageToLunpan()
    {
        for(int i=0;i<SoundKnapsack.Count;i++)
        {
            for(int q=0;q<SoundUI.Count;q++)
            if (SoundUI[q].GetComponent<Image>().sprite == NoneImage)
            {
                AddonClickEnvent(q, SoundKnapsack[i].ActionName);
                ChangeImage(q, SoundKnapsack[i].SoundImage);
                    if (SoundKnapsack[i].SoundOrMonoUI == TYPE.MonoUI) Destroy(SoundKnapsack[i].My_Obj);
                    return;
            }
        }
    }


}
