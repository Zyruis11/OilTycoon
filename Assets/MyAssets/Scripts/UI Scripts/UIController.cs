using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    public int oilSellPrice; 
    public Text oilText;
    public Text moneyText;
    public GameObject buildMenu;
    public Button testButton;
    public Toggle[] buildButtons; 

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        oilText.text = "Oil: " + PlayerStats._Oil + "/" + PlayerStats._OilStorage;
        moneyText.text = "Money: " + PlayerStats._Money;
	}

    //Shows/Hides the build menu 
    public void ShowBuildMenu()
    {
        Text buttonText = testButton.GetComponentInChildren<Text>();
        if (buildMenu.active == false)
        {
            buildMenu.active = true;
            buttonText.text = "Hide";
        }
        else
        {
            buildMenu.active = false;
            buttonText.text = "Show";
        }
    }

    public void ChangeBuildItem()
    {
        for (int i = 0; i < buildButtons.Length; i++)
        {
            if (buildButtons[i].isOn == true)
            {
                Debug.Log("Button Selected" + buildButtons[i].name);
                BuildingPlacement.index = i; 
            }
        }
    }

    #region debugMenu
    public void AddMoney()
    {
        PlayerStats._Money += 1000;
    }

    public void AddOil()
    {
        PlayerStats._Oil += 100;
    }

    public void AddStorage()
    {
        PlayerStats._OilStorage += 100;
    }
    #endregion debugMenu 

    //Sells all of the player's current collected oil 
    public void SellAllOil()
    {
        if (PlayerStats._Oil > 0)
        { 
            PlayerStats._Money += PlayerStats._Oil * oilSellPrice;
            PlayerStats._Oil = 0;
        }
    }
}
