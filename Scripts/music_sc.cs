using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_sc : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private static music_sc instance = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
            audioSource = GetComponent<AudioSource>();
            return;
        }
        Destroy(this.gameObject);
    }

    public void playmusic()
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();
    }

    public void stopmusic()
    {
        audioSource.Stop();
    }
}
