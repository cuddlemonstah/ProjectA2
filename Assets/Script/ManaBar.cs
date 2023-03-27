using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public void setMana(float mana)
    {
        slider.value = mana;
    }
    public void setMaxMana(float maxMana)
    {
        slider.maxValue = maxMana;
    }
}
