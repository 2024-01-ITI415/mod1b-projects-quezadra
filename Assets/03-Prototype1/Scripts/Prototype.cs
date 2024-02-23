using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum pGameMode
{ // b
    idle,
    playing,
    lev
}

public class Prototype : MonoBehaviour
{
    static private Prototype S; // a private Singleton
    [Header("Set in Inspector")]
    public Text uitLevel; // The UIText_Level Text
    public Vector3 castlePos; // The place to put castles
    public Text uitButton; // The Text on UIButton_View
    public GameObject[] mazes; // An array of the castles
    [Header("Set Dynamically")]
    public int level; // The current level
    public int levelMax; // The number of levels
    public int shotsTaken;
    public GameObject maze; // The current castle
    public pGameMode mode = pGameMode.idle;

    void Start()
    {
        S = this; // Define the Singleton
        level = 0;
        levelMax = mazes.Length;
        StartLevel();
    }
    void StartLevel()
    {
        // Get rid of the old castle if one exists
        if (maze != null)
        {
            Destroy(maze);
        }
        // Destroy old projectiles if they exist
        GameObject[] gos = GameObject.FindGameObjectsWithTag("_Player");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }
        // Instantiate the new castle
        maze = Instantiate<GameObject>(mazes[level]);
        maze.transform.position = castlePos;
        shotsTaken = 0;
        // Reset the camera
//SwitchView("wShow Both");
        ProjectileLine.S.Clear();
        // Reset the goal
        Goal.goalMet = false;
        UpdateGUI();
        mode = pGameMode.playing;
    }
    void UpdateGUI()
    {
        // Show the data in the GUITexts
        uitLevel.text = "Level: " + (level + 1) + "of " + levelMax;
       
    }
    void Update()
    {
        //UpdateGUI();
        // Check for level end
        //if ((mode == pGameMode.playing) && Goal_.goalMet)
        {
            // Change mode to stop checking for level end
            //mode = pGameMode.levelEnd;
            // Zoom out
            //SwitchView("Show Both");
            // Start the next level in 2 seconds
            //Invoke("NextLevel", 2f);
        }
    }
    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }
    
   
    // Static method that allows code anywhere to increment shotsTaken
    public static void ShotFired()
    { // d
        S.shotsTaken++;
    }

}
