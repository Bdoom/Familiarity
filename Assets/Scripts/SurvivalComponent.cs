using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalComponent : MonoBehaviour
{
    public float SURVIVAL_TIMER_COOLDOWN = 10f;
    public int FOOD_REDUCTION_PER_TIMER = 3;
    public int WATER_REDUCTION_PER_TIMIER = 3;
    private StatsComponent stats;

    private void Start()
    {
        stats = GetComponent<StatsComponent>();
        StartCoroutine(SurvivalTimer());
    }

    IEnumerator SurvivalTimer()
    {
        while (true)
        {

            if (stats.Food <= 0 && stats.Water <= 0)
            {
                stats.TakeDamage(3);
            }
            stats.ReduceFood(6);
            stats.ReduceWater(3);

            yield return new WaitForSeconds(SURVIVAL_TIMER_COOLDOWN);

        }
    }

}
