using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAp : MonoBehaviour
{
    //?its for the ability sheet... the buttons in the lvlup prefab
    public void Fireball()
    {
        resume();
    }

    public void Magic()
    {
        resume();
    }

    public void AddDamage()
    {
        resume();
    }

    private void resume()
    {
        UIManager manage = FindObjectOfType<UIManager>();
        manage.lvlUPS.SetActive(false);
        Time.timeScale = 1f;
        UIManager.GameIsPaused = false;
    }
}
