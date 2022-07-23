using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent(typeof(AudioSource))]
public class HeroAudioController : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] List<AudioClip> _attackVoiceClips;
    [SerializeField] List<AudioClip> _specialAttackVoiceClips;
    [SerializeField] List<AudioClip> _hurtVoiceClips;
    [SerializeField] List<AudioClip> _startTurnVoiceClips;
    [SerializeField] List<AudioClip> _evadeVoiceClips;
    [SerializeField] List<AudioClip> _guardVoiceClips;
    [SerializeField] List<AudioClip> _startGuardVoiceClips;
    [SerializeField] List<AudioClip> _selfBuffVoiceClips;
    [SerializeField] List<AudioClip> _itemUseVoiceClips;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAttackVoice()
    {
        _audioSource.Stop();
        int index = Random.Range(0, _attackVoiceClips.Count);
        _audioSource.PlayOneShot(_attackVoiceClips[index]);
    }

    public void PlaySpecialAttackVoice()
    {
        _audioSource.Stop();
        int index = Random.Range(0, _specialAttackVoiceClips.Count);
        _audioSource.PlayOneShot(_specialAttackVoiceClips[index]);
    }

    public void PlayHurtVoice()
    {
        _audioSource.Stop();
        int index = Random.Range(0, _hurtVoiceClips.Count);
        _audioSource.PlayOneShot(_hurtVoiceClips[index]);
    }

    public void PlayStartTurnVoice()
    {
        _audioSource.Stop();
        int index = Random.Range(0, _startTurnVoiceClips.Count);
        _audioSource.PlayOneShot(_startTurnVoiceClips[index]);
    }

    public void PlayEvadeVoice()
    {
        _audioSource.Stop();
        int index = Random.Range(0, _evadeVoiceClips.Count);
        _audioSource.PlayOneShot(_evadeVoiceClips[index]);
    }
    public void PlayStartGuardVoice()
    {
        _audioSource.Stop();
        int index = Random.Range(0, _startGuardVoiceClips.Count);
        _audioSource.PlayOneShot(_startGuardVoiceClips[index]);
    }

    public void PlayGuardVoice()
    {
        _audioSource.Stop();
        int index = Random.Range(0, _guardVoiceClips.Count);
        _audioSource.PlayOneShot(_guardVoiceClips[index]);
    }
    public void PlaySelfBuffVoice()
    {
        _audioSource.Stop();
        int index = Random.Range(0, _selfBuffVoiceClips.Count);
        _audioSource.PlayOneShot(_selfBuffVoiceClips[index]);
    }

    public void PlayItemUseVoice()
    {
        _audioSource.Stop();
        int index = Random.Range(0, _itemUseVoiceClips.Count);
        _audioSource.PlayOneShot(_itemUseVoiceClips[index]);
    }

}