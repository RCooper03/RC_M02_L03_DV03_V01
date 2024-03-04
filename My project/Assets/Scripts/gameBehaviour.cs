using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CustomExtensions;

using UnityEngine.SceneManagement;

public class gameBehaviour : MonoBehaviour, IManager
{
    private string state;

    public string State
    {
        get { return state; }
        set { state = value; }
    }
    
    public string labelText = "Collect all 4 items to proceed";
    public int maxItems = 4;
    public int ammoCount = 0;
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public int armourCount;

    private int itemsCollected = 0;

    public int Items
    {
        get { return itemsCollected; }

        set
        {
            itemsCollected = value;
            Debug.LogFormat("Items: {0}", itemsCollected);

            if(itemsCollected >= maxItems)
            {
                labelText = "You've found all items";
                showWinScreen = true;

                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - itemsCollected) + " more to go";
            }
        }

    }

    private int playerHP = 10;
    public int HP
    {
        get { return playerHP; }
        set
        {
            playerHP = value;

            if(playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's got hurt.";
            }

            Debug.LogFormat("Lives: {0}", playerHP);
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + playerHP);

        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + itemsCollected);

        GUI.Box(new Rect(20, 80, 150, 25), "Ammo: " + ammoCount);

        GUI.Box(new Rect(20, 110, 150, 25), "Armour: " + armourCount);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "You can now continue."))
            {
                //SceneManager.LoadScene(0);

                //Time.timeScale = 1.0f;

                Utilities.RestartLevel(0);
            }

            if (showLossScreen)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
                {
                    //SceneManager.LoadScene(0);
                    //Time.timeScale = 1.0f;

                    Utilities.RestartLevel();
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        state = "Manager initialized..";

        state.FancyDebug();

        Debug.Log(state);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
