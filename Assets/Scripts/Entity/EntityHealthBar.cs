using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EntityHealthBar : MonoBehaviour
{
    public Attackable attackable;

    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject blockObj;
    [SerializeField] TextMeshProUGUI blockText;

    public void SetParams(Attackable attackable)
    {
        this.attackable = attackable;

        // Events
        attackable.changeHealthEvent += UpdateHealthBar;
        attackable.changeBlockEvent += UpdateBlock;
    }

    void UpdateHealthBar(int health, int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;

        healthText.text = slider.value + "/" + slider.maxValue;

        if (health <= 0)
        {
            DestroyHealthBar();
        }
    }

    void UpdateBlock(int block)
    {
        blockText.text = block.ToString();

        // Block icon invisible if no block
        blockObj.SetActive(block != 0);
    }

    void DestroyHealthBar()
    {
        Destroy(gameObject);
    }
}
