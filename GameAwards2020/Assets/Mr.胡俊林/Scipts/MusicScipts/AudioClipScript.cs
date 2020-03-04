using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipScript : MonoBehaviour
{
    [SerializeField] AudioClip m_AudioClip;     // 鳴らしたい音

    private AudioManager m_AudioManager;    // 格納用
    private int m_SourceIndex = -1;     // AudioSourceManagerが持つ、何番目のAudioSourceか

    // Use this for initialization
    void Awake()
    {
        // AudioManagerを格納
        m_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void SetAudioClip(bool _loop)
    {
        // indexに、AudioSource（中身がnull）の配列番号格納
        // nullなAudioSourceがなければ一番古く追加された番号が返ってくる
        m_SourceIndex = m_AudioManager.GetNullAudioSourceNum();
        if (m_SourceIndex == -1)
        {
            int a = 0;
        }
        // AudioSourceManagerのAudioSourceにAudioClipをセット
        m_AudioManager.SetAudioClip(m_SourceIndex, m_AudioClip, _loop);
    }

    // SE用
    public void PlayOneShot()
    {
        // ロックしない
        SetAudioClip(false);
        // 音再生
        m_AudioManager.PlayOneShot(m_SourceIndex);
    }

    public void PlayOneShot(float _startTime)
    {
        // ロックしない
        SetAudioClip(false);
        // 音再生
        m_AudioManager.PlayOneShot(m_SourceIndex, _startTime);
    }

    public void PlayOneShotVolume(float _volume)
    {
        // ロックしない
        SetAudioClip(false);
        // ボリューム変更
        m_AudioManager.SetVolume(m_SourceIndex, _volume);
        // 音再生
        m_AudioManager.PlayOneShot(m_SourceIndex);
    }

    // BGM用
    public void SetAndPlay()
    {
        // ロック
        SetAudioClip(true);
        // 音再生
        m_AudioManager.Play(m_SourceIndex);
    }
    public void Play()
    {
        // 音再生
        m_AudioManager.Play(m_SourceIndex);
    }

    public void Play(float _startTime)
    {
        // 音再生
        m_AudioManager.Play(m_SourceIndex, _startTime);
    }

    public void Stop() { m_AudioManager.Stop(m_SourceIndex); }

    public void StopAll() { m_AudioManager.StopAll(); }
    // 調整
    public void VolumeSetLerp(float _standardVolume, float _targetVolume, float _lerpScale)
    {
        m_AudioManager.VolumeSetLerp(m_SourceIndex, _standardVolume, _targetVolume, _lerpScale);
    }

    public void SetLawPassBGM(float _num)
    {
        m_AudioManager.SetLawPassBGM(_num);
    }

    public void SetVolume(float _num)
    {
        m_AudioManager.SetVolume(m_SourceIndex, _num);
    }

    public void SetPitch(float _num)
    {
        m_AudioManager.SetPitch(m_SourceIndex, _num);
    }

    public void VolumeAdjustment()
    {
        m_AudioManager.VolumeAdjustment();
    }

    public void UnLock()
    {
        m_AudioManager.SetLock(m_SourceIndex, false);
    }

    // Get
    public int GetIndex()
    {
        return m_SourceIndex;
    }

    public float GetVolume()
    {
        return m_AudioManager.GetVolume(m_SourceIndex);
    }
}