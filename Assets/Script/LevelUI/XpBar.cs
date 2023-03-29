using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public Text LvlText;
    public void setXp(float Xp)
    {
        slider.value = Xp;
    }
    public void setMaxXp(float maxXp)
    {
        slider.maxValue = maxXp;
    }
    public void setLvlText(int curLevel)
    {
        LvlText.text = curLevel.ToString();
    }
}
