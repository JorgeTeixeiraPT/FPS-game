using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;
   public void UpdateAmmo(int count)
    {
        ammoText.text = "Ammo: " + count;
    }
}
