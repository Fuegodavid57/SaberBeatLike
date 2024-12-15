using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundComponent : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip perfect;
    [SerializeField] AudioClip average;
    [SerializeField] AudioClip miss;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(HIT_TYPE _hitType)
    {
        switch (_hitType)
        {
            case HIT_TYPE.PERFECT:
                audioSource.clip = null;
                audioSource.PlayOneShot(perfect);
                break;
            case HIT_TYPE.AVERAGE:
                audioSource.clip = null;
                audioSource.PlayOneShot(average);
                break;
            case HIT_TYPE.MISS:
                audioSource.clip = null;
                audioSource.PlayOneShot(miss);
                break;
        }
    }
}
