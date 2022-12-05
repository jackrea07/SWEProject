using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Image currentLives;
    public Image totalLives;
    public PlayerHealth playerhealth;

    // Start is called before the first frame update
    void Start()
    {
        totalLives.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        currentLives.fillAmount = playerhealth.numLives / 3f;


    }
}