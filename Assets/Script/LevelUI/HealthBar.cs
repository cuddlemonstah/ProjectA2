using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setHP(float health)
    {
        slider.value = health;
    }
    public void setMaxHP(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

  
}
