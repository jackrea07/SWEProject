using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SegmentHealth : MonoBehaviour
{
    public Image currentHealth;
    public Image totalHealth;
    public PlayerHealth playerhealth;

    // Start is called before the first frame update
    void Start()
    {
        totalHealth.fillAmount = playerhealth.maxHealth / 10f;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth.fillAmount = playerhealth.currentHealth / 10f;


    }
}