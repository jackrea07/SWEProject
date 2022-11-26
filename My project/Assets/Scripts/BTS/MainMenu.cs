using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public levelchange leveler;
    // Start is called before the first frame update
    public void playGame() {
        leveler.fadetolevel("Test Scene");

        
    }
    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();


    }
}
