using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{


    private DateTime quitTime;
    private DateTime startTime;
    public double timespandate;
    public double runtimespandate;
    public righttotry right;
    private void Awake()
    {
        // Get the start date when game objects are created
        startTime = DateTime.Now;

        // You can take any action using the start date
        Debug.Log("Game start date: " + startTime.ToString());




    }
    private void Start()
    {
        gameclosed.DontDestroyOnLoad(this);
        string dateQuitstring = PlayerPrefs.GetString("dateQuit");
        if (!dateQuitstring.Equals(""))
        {
            DateTime dateQuit = DateTime.Parse(dateQuitstring);
            DateTime dateNow = DateTime.Now;
            if (dateNow > dateQuit)
            {
                TimeSpan timespan = dateNow - dateQuit;
                Debug.Log("quit for " + timespan.TotalSeconds + "seconds");
                timespandate = timespan.TotalSeconds;
               //Total time out of game timespandate
            }
            PlayerPrefs.SetString("dateQuit", "");
        }
    }
    private void OnApplicationQuit()
    {
        // Date and time of exit from the game
        quitTime = DateTime.Now;
        TimeSpan elapsedTime = quitTime - startTime;
        PlayerPrefs.SetString("dateQuit", quitTime.ToString());
        runtimespandate = elapsedTime.TotalSeconds;
        // You can take any action using the date of exit from the game
        Debug.Log("Date of exit from the game: " + quitTime.ToString());
        Debug.Log("Time Spent in Game: " + elapsedTime.TotalSeconds + " second");
    }

}
