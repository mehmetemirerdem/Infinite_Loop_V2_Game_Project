using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu_sc : MonoBehaviour
{
    public Button Continuebutton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("saved_level6") != 0)
        {
            Continuebutton.gameObject.SetActive(true);
        }
        else
        {
            Continuebutton.gameObject.SetActive(false);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        if (PlayerPrefs.GetInt("saved_level6") != 0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("saved_level6"));
        }
        else
        {
            return;
        }
    }
}
