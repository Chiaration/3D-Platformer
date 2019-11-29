using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSound;

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClickSoundPlayer()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource.PlayOneShot(buttonClickSound);
    }
}
