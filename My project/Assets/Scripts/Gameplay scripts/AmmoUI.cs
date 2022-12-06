using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    public TextMeshProUGUI ammotext;
    public Weapon ammocount;
    // Start is called before the first frame update
    void Start()
    {
        ammotext.text = "x" +20.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoCount(ammocount.currentAmmo);
    }
    public void UpdateAmmoCount(int playerAmmo) {
        ammotext.text = "x" +playerAmmo.ToString();
    }
}
