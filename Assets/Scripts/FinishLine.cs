using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 3f;
    [SerializeField] ParticleSystem FinishEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FinishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("OpenScene", delayTime);
        }
    }
    void OpenScene()
    {
         SceneManager.LoadScene(0); 
    }
}
