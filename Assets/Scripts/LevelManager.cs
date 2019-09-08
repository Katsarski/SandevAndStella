using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Respawn locations
    //Level boundaries
    public static LevelManager instance;
    public int levelNumber;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        if (Time.timeScale>0.0f)
        {
            Time.timeScale = 0;
        }
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }

}
