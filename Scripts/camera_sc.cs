using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class camera_sc : MonoBehaviour
{
    public GameObject canvas;

    private bool flag = false;

    public AudioClip jump_sound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (flag)
            {
                Resume();
            }
            else
            {
                canvas.SetActive(true);
                Time.timeScale = 0f;
                flag = true;
            }
        }

        if (Input.GetAxis("Jump") > 0.0f)
        {
            audioSource.clip = jump_sound;
            audioSource.loop = false;
            audioSource.Play();
        }
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        flag = false;
    }

    public void Pause()
    {
        //restart in the same scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainmenu()
    {
        PlayerPrefs.SetInt("saved_level6", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
}
