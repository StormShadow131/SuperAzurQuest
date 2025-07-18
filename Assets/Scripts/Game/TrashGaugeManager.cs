using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashGaugeManager : MonoBehaviour
{
    public Slider gaugeSlider;
    public int enemyKilled = 0;
    public int enemyRequired = 8;

    public void AddDeadEnemy()
    {
        enemyKilled++;
        UpdateGauge();
    }

    private void UpdateGauge()
    {
        float ratio = (float)enemyKilled / enemyRequired;
        Debug.Log("MAJ jauge : " + enemyKilled + "/" + enemyRequired + " ->" + ratio);

        if (gaugeSlider == null)
        {
            Debug.LogError("gaugeSlider est NULL !");
        }
        else
        {
            gaugeSlider.value = ratio;
        }
    }

    public bool FullGauge()
    {
        return enemyKilled >= enemyRequired;
    }
}
