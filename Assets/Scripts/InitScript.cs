using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, new RefreshRate { numerator = 60, denominator = 1 });
            
        
        SceneManager.LoadScene((int)SceneBuildIndex.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
