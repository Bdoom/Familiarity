using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsComponent : MonoBehaviour
{
    private float MaxDefault = 100;

    public float MovementSpeed { get; private set; }
    public float Food { get; private set; }
    public float Water { get; private set; }
    public float Weight { get; private set; }
    public float Health { get; private set; }

    public float MaxWeight { get => MaxDefault; }
    public float MaxFood { get => MaxDefault; }
    public float MaxHealth { get => MaxDefault; }
    public float MaxWater { get => MaxDefault; }

    private GameObject HealthBar;
    private GameObject FoodBar;
    private GameObject WaterBar;


    private void Start()
    {
        MovementSpeed = 5;
        Food = MaxFood;
        Water = MaxWater;
        Health = MaxHealth;
        Weight = 0;

        HealthBar = GameObject.Find("Health Bar");
        FoodBar = GameObject.Find("Food Bar");
        WaterBar = GameObject.Find("Water Bar");

        ResetUIStatBarsToFull();
    }

    private void ResetUIStatBarsToFull()
    {   
        RectTransform bar = HealthBar.GetComponent<RectTransform>();
        bar.localScale = new Vector3(1, 1, 1);
        bar = FoodBar.GetComponent<RectTransform>();
        bar.localScale = new Vector3(1, 1, 1);
        bar = WaterBar.GetComponent<RectTransform>();
        bar.localScale = new Vector3(1, 1, 1);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        float newX = Food / MaxHealth;
        RectTransform bar = HealthBar.GetComponent<RectTransform>();
        bar.localScale = new Vector3(newX, 1, 1);
    }

    public void ReduceFood(float amount)
    {
        Food -= amount;
        float newX = Food / MaxFood;
        RectTransform bar = FoodBar.GetComponent<RectTransform>();
        bar.localScale = new Vector3(newX, 1, 1);
    }

    public void AddFood(float amount)
    {
        Food += amount;
        float newX = Food / MaxFood;
        RectTransform bar = FoodBar.GetComponent<RectTransform>();
        bar.localScale = new Vector3(newX, 1, 1);
    }

    public void ReduceWater(float amount)
    {
        Water -= amount;
        float newX = Water / MaxWater;
        RectTransform bar = WaterBar.GetComponent<RectTransform>();
        bar.localScale = new Vector3(newX, 1, 1);
    }

    public void AddWater(float amount)
    {
        Water += amount;
        float newX = Water / MaxWater;
        RectTransform bar = WaterBar.GetComponent<RectTransform>();
        bar.localScale = new Vector3(newX, 1, 1);
    }

    public void ReduceWeight(float amount)
    {
        Weight -= amount;
    }

    public void AddWeight(float amount)
    {
        Weight += amount;
    }

}
