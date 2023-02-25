using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodCounter : MonoBehaviour

{

    public static FoodCounter instance;

    public TMP_Text foodText;
    public int currentFood = 0;


    void Awake()
    {
        instance = this;
    }
    //initial text for food collection

    void Start()
    {
        foodText.text = "Food Collected: " + currentFood.ToString();
    }

    // updates text to value of points 
    public void IncreaseFood(int v)
    {
        currentFood += v;
        foodText.text = "Food Collected: " + currentFood.ToString();



    }




}
