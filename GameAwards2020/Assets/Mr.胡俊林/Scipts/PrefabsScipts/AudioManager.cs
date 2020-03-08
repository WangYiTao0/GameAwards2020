using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    protected struct SoundInfoStruct
    {
        public float StandardVolume;
        public float TargetVolume;
        public float Time;
        public float LerpScale;
        public bool Adjustment;
    };

    // AudioSourceごとの構造体
    private struct AudioSourceStruct
    {
        public AudioSource AudioSource;     // オーディオソース
        public SoundInfoStruct SoundInfo;     // 音ごとの情報（音量など）
        public int AddNumber;       // 音の入れ替え時に使う値
        public bool Lock;       // 開放したくない音用フラグ
    };

    private const float LAW_PASS_MAX = 9000.0f;
    private const float LAW_PASS_MIN = 5000.0f;

    [SerializeField] private int m_Otoga_Doujini_Naru_Kazu;         // 同時に音が鳴る数

    [SerializeField] private AudioMixer BGM_Mixer;
    [SerializeField] private AudioMixerGroup BGM_MixerGroup;
    [SerializeField] private AudioMixerGroup SE_MixerGroup;

    private AudioSourceStruct[] m_AudioSourceStruct;        // 構造体のインスタンス
    int m_AudioCount;      // セットされた音の数
    private bool m_Adjust;

    // Use this for initialization
    void Awake()
    {
        // 指定された数分を初期化
        m_AudioSourceStruct = new AudioSourceStruct[m_Otoga_Doujini_Naru_Kazu];

        for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
        {
            // 指定された数分のAudioSource追加
            m_AudioSourceStruct[i].AudioSource = gameObject.AddComponent<AudioSource>();
            // ロックフラグ初期化
            m_AudioSourceStruct[i].Lock = false;
        }

        // セットされた音の数初期化
        m_AudioCount = 0;

        m_Adjust = false;

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        VolumeAdjustment();
        //SpeedAdjustment();
    }

    public void Play(int _sourceIndex)
    {
        // 指定されたインデックスのAudioSourceを鳴らす
        if (m_AudioSourceStruct[_sourceIndex].AudioSource == null)
        {
            Debug.Log(_sourceIndex + "番目のAudioSourceにClipがありません");
            return;
        }
        m_AudioSourceStruct[_sourceIndex].AudioSource.Play();
    }

    public void Play(int _sourceIndex, float _startTime)
    {
        // 指定されたインデックスのAudioSourceを鳴らす
        if (m_AudioSourceStruct[_sourceIndex].AudioSource == null)
        {
            Debug.Log(_sourceIndex + "番目のAudioSourceにClipがありません");
            return;
        }
        m_AudioSourceStruct[_sourceIndex].AudioSource.time = _startTime;
        m_AudioSourceStruct[_sourceIndex].AudioSource.Play();
    }

    public void PlayOneShot(int _sourceIndex)
    {
        // 指定されたインデックスのAudioSourceを鳴らす
        if (m_AudioSourceStruct[_sourceIndex].AudioSource == null)
        {
            Debug.Log(_sourceIndex + "番目のAudioSourceにClipがありません");
            return;
        }
        m_AudioSourceStruct[_sourceIndex].AudioSource.Play();

        // 音が鳴り終わったかどうかチェック
        StartCoroutine(Checking(_sourceIndex));
    }

    public void PlayOneShot(int _sourceIndex, float _startTime)
    {
        // 指定されたインデックスのAudioSourceを鳴らす
        if (m_AudioSourceStruct[_sourceIndex].AudioSource == null)
        {
            Debug.Log(_sourceIndex + "番目のAudioSourceにClipがありません");
            return;
        }
        m_AudioSourceStruct[_sourceIndex].AudioSource.time = _startTime;
        m_AudioSourceStruct[_sourceIndex].AudioSource.Play();

        // 音が鳴り終わったかどうかチェック
        StartCoroutine(Checking(_sourceIndex));
    }

    public void PlayClipAtPoint(int _index, Vector3 _pos)
    {
        AudioSource.PlayClipAtPoint(m_AudioSourceStruct[_index].AudioSource.clip, _pos);
        // 音が鳴り終わったかどうかチェック
        StartCoroutine(Checking(_index));
    }

    public void Stop(int _SourceIndex)
    {
        // 指定されたインデックスのAudioSourceの再生を止める
        if (m_AudioSourceStruct[_SourceIndex].AudioSource.clip == null)
        {
            Debug.Log(_SourceIndex + "番目のAudioSourceにClipがありません");
            return;
        }
        m_AudioSourceStruct[_SourceIndex].AudioSource.Stop();
    }

    public void StopAll()
    {
        for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
        {
            SetLock(i, false);
            SetLoop(i, false);
            m_AudioSourceStruct[i].AudioSource.clip = null;
            m_AudioSourceStruct[i].AudioSource.pitch = 1.0f;
            m_AudioSourceStruct[i].AudioSource.outputAudioMixerGroup = null;
        }
    }

    public void SwitchBGM(int _newIndex, int _oldIndex, float _standardVolume, float _targetVolume, float _lerpScale, float _newSoundStartTime)
    {
        // 指定したindexのAudioMixerがBGMじゃないならreturn
        if (m_AudioSourceStruct[_newIndex].AudioSource.outputAudioMixerGroup != BGM_MixerGroup ||
            m_AudioSourceStruct[_oldIndex].AudioSource.outputAudioMixerGroup != BGM_MixerGroup) return;

        /* 音量の調整のための値をセット
        _newIndex, _oldIndex : サウンド,
        _standardVolume      : 基準音量,
        _targetVolume        : 目標音量
        _lerpScale           : 線形補間の速さの倍率
        */

        // 新たに流したいBGM
        m_AudioSourceStruct[_newIndex].SoundInfo.StandardVolume = 0.1f;
        m_AudioSourceStruct[_newIndex].SoundInfo.TargetVolume = _targetVolume;
        m_AudioSourceStruct[_newIndex].SoundInfo.Time = 0.0f;
        m_AudioSourceStruct[_newIndex].SoundInfo.LerpScale = _lerpScale;
        m_AudioSourceStruct[_newIndex].SoundInfo.Adjustment = true;
        m_AudioSourceStruct[_newIndex].AudioSource.time = _newSoundStartTime;

        // 終了させたいBGM
        m_AudioSourceStruct[_oldIndex].SoundInfo.StandardVolume = _standardVolume;
        m_AudioSourceStruct[_oldIndex].SoundInfo.TargetVolume = 0.0f;
        m_AudioSourceStruct[_oldIndex].SoundInfo.Time = 0.0f;
        m_AudioSourceStruct[_oldIndex].SoundInfo.LerpScale = _lerpScale;
        m_AudioSourceStruct[_oldIndex].SoundInfo.Adjustment = true;
    }

    // 音量調整
    public void VolumeAdjustment()
    {
        for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
        {
            if (m_AudioSourceStruct[i].AudioSource == null) continue;
            if (m_AudioSourceStruct[i].AudioSource.clip == null) continue;

            // Adjustmentフラグがfalseなら
            if (!m_AudioSourceStruct[i].SoundInfo.Adjustment)
            {
                continue;
            }
            // 指定した秒数で指定したボリュームまで変化
            m_AudioSourceStruct[i].AudioSource.volume = Mathf.Lerp(m_AudioSourceStruct[i].SoundInfo.StandardVolume, m_AudioSourceStruct[i].SoundInfo.TargetVolume, m_AudioSourceStruct[i].SoundInfo.Time);
            // 秒数加算
            m_AudioSourceStruct[i].SoundInfo.Time += Time.deltaTime * m_AudioSourceStruct[i].SoundInfo.LerpScale;

            // 線形補完のカウントが1.0f以上で
            if (m_AudioSourceStruct[i].SoundInfo.Time >= 1.0f)
            {
                // 秒数リセット
                m_AudioSourceStruct[i].SoundInfo.Time = 0.0f;
                // 調整中のフラグリセット
                m_AudioSourceStruct[i].SoundInfo.Adjustment = false;
            }
        }
    }

    // BGMのフェードアウト
    public void VolumeFadeOut(float _lerpScale)
    {
        //_lerpScale      : 線形補間の速さの倍率

        for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
        {
            // BGMだけフェードアウト
            if (m_AudioSourceStruct[i].AudioSource.outputAudioMixerGroup == BGM_MixerGroup)
            {
                m_AudioSourceStruct[i].SoundInfo.StandardVolume = m_AudioSourceStruct[i].AudioSource.volume;
                m_AudioSourceStruct[i].SoundInfo.TargetVolume = 0.0f;
                m_AudioSourceStruct[i].SoundInfo.Time = 0.0f;
                m_AudioSourceStruct[i].SoundInfo.LerpScale = _lerpScale;
                m_AudioSourceStruct[i].SoundInfo.Adjustment = true;
            }
        }
    }

    // 音量変化する値のセット
    public void VolumeSetLerp(int _index, float _standardVolume, float _targetVolume, float _lerpScale)
    {
        /* 音量の調整のための値をセット
        _index : サウンド,
        _standardVolume : 基準音量,
        _targetVolume   : 目標音量
        _lerpScale      : 線形補間の速さの倍率
        */
        m_AudioSourceStruct[_index].SoundInfo.StandardVolume = _standardVolume;
        m_AudioSourceStruct[_index].SoundInfo.TargetVolume = _targetVolume;
        m_AudioSourceStruct[_index].SoundInfo.Time = 0.0f;
        m_AudioSourceStruct[_index].SoundInfo.LerpScale = _lerpScale;
        m_AudioSourceStruct[_index].SoundInfo.Adjustment = true;
    }

    public void SetSpeedBGM(float _speed)
    {
        BGM_Mixer.SetFloat("PitchValue", _speed);
    }
    public void SetLawPassBGM(float _lowPass)
    {
        BGM_Mixer.SetFloat("LowPass", _lowPass);
    }

    //public void SpeedAdjustment()
    //{
    //    if (ShuffleManager.IsFrameHold)
    //    {
    //        if (!m_Adjust)
    //        {

    //            SetLawPassBGM(LAW_PASS_MIN);  // BGM_MixerのPitchSifterのpitchを２倍に
    //            SetSpeedBGM(1.0999f);
    //            for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
    //            {
    //                if (m_AudioSourceStruct[i].AudioSource.outputAudioMixerGroup == BGM_MixerGroup)
    //                {
    //                    m_AudioSource[i].pitch = 0.9f;  // AudioSourceのpitchを半分に
    //                }
    //            }
    //            m_Adjust = true;
    //        }
    //    }
    //    else
    //    {
    //        if (m_Adjust)
    //        {
    //            SetLawPassBGM(LAW_PASS_MAX);  // BGM_MixerのPitchSifterのpitchを等倍に

    //            SetSpeedBGM(1.0f);
    //            for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
    //            {
    //                if (m_AudioSourceStruct[i].AudioSource.outputAudioMixerGroup == BGM_MixerGroup)
    //                {
    //                    m_AudioSourceStruct[i].AudioSource.pitch = 1.0f;  // AudioSourceのpitchを等倍に
    //                }
    //            }
    //            m_Adjust = false;
    //        }
    //    }
    //}

    public void SetAudioClip(int _index, AudioClip _clip, bool _loop)
    {
        // clipをsetする時に、追加された順番も保存
        m_AudioSourceStruct[_index].AudioSource.clip = _clip;
        // clipによってミキサーセット
        if (_loop)
        {
            m_AudioSourceStruct[_index].AudioSource.outputAudioMixerGroup = BGM_MixerGroup;
            SetLoop(_index, true);
        }
        else
        {
            m_AudioSourceStruct[_index].AudioSource.outputAudioMixerGroup = SE_MixerGroup;
        }
        m_AudioSourceStruct[_index].AddNumber = m_AudioCount;
        SetLock(_index, _loop);
        m_AudioCount++;
    }

    public void SetLock(int _index, bool _lock) { m_AudioSourceStruct[_index].Lock = _lock; }
    public void SetLoop(int _index, bool _loop) { m_AudioSourceStruct[_index].AudioSource.loop = _loop; }
    public void SetVolume(int _index, float _volume) { m_AudioSourceStruct[_index].AudioSource.volume = _volume; }
    public void SetPitch(int _index, float _pitch) { m_AudioSourceStruct[_index].AudioSource.pitch = _pitch; }


    public float GetVolume(int _index)
    {
        return m_AudioSourceStruct[_index].AudioSource.volume;
    }

    public int GetNullAudioSourceNum()
    {
        // AudioSourceの検索
        for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
        {
            // AudioSourceのクリップがnullかつロックされてないなら
            if (m_AudioSourceStruct[i].AudioSource.clip == null && m_AudioSourceStruct[i].Lock != true)
            {
                return i;
            }
        }

        // 以後、上記条件に合うAudioSourceが見つからなかったら
        int min = -1;
        int returnNum = -1;

        // 最初に比較される追加番号格納
        for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
        {
            if (m_AudioSourceStruct[i].Lock != true)
            {
                // 最小値に初期値セット
                min = m_AudioSourceStruct[i].AddNumber;
                // とりあえずreturnNum格納
                returnNum = i;
                break;
            }
        }

        // 0番目から順に比較
        for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
        {
            // returnNum
            if (min > m_AudioSourceStruct[i].AddNumber && m_AudioSourceStruct[i].Lock != true)
            {
                // 比較する値更新
                min = m_AudioSourceStruct[i].AddNumber;
                // returnする値も更新
                returnNum = i;
            }
        }
        return returnNum;
    }

    public void ClearAudioSource(bool _lockDelete)
    {
        if (!_lockDelete)
        {
            for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
            {
                if (!m_AudioSourceStruct[i].Lock)
                {
                    m_AudioSourceStruct[i].AudioSource = null;
                }
            }

        }
        else
        {
            for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
            {
                SetLock(i, false);
                m_AudioSourceStruct[i].AudioSource = null;
            }
        }
    }

    public void ClearBGM()
    {
        for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
        {
            if (m_AudioSourceStruct[i].AudioSource.outputAudioMixerGroup == BGM_MixerGroup)
            {
                SetLock(i, false);
                SetLoop(i, false);
                m_AudioSourceStruct[i].AudioSource.clip = null;
                m_AudioSourceStruct[i].AudioSource.pitch = 1.0f;
                m_AudioSourceStruct[i].AudioSource.outputAudioMixerGroup = null;
            }
        }
    }

    public void ClearSE()
    {
        for (int i = 0; i < m_Otoga_Doujini_Naru_Kazu; i++)
        {
            if (!m_AudioSourceStruct[i].AudioSource.outputAudioMixerGroup == SE_MixerGroup)
            {
                m_AudioSourceStruct[i].AudioSource.clip = null;
            }
        }
    }

    // 音が鳴り終わったかどうか判別
    private IEnumerator Checking(int _index)
    {
        while (true)
        {
            // １フレーム(FixedUpdateが呼ばれるまで)待って
            yield return new WaitForFixedUpdate();
            // _indexの音が鳴り終わったら
            if (!m_AudioSourceStruct[_index].AudioSource.isPlaying)
            {
                Debug.Log("再生終了");
                // 終了したらclipをnullに
                m_AudioSourceStruct[_index].Lock = false;
                m_AudioSourceStruct[_index].AudioSource.clip = null;
                m_AudioSourceStruct[_index].AudioSource.outputAudioMixerGroup = null;
                break;
            }
        }
    }
}