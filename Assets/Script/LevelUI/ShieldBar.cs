using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;
    public void setHP(float shield)
    {
        slider.value = shield;
    }
    public void setMaxHP(float maxShield)
    {
        slider.maxValue = maxShield;
    }
}
