using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool crashedAlready = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground"&&!crashedAlready) 
        {
            crashedAlready = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            //GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke ("OpenScene",delayTime);
        }
    }
    void OpenScene()
    {
        { SceneManager.LoadScene(0);}
    }
}
