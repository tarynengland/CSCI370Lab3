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

    // Start is called before the first frame update
    void Start()
    {
        foodText.text = "Food Collected: " + currentFood.ToString();
    }

    // Update is called once per frame
    public void IncreaseFood(int v)
    {
        currentFood += v;
        foodText.text = "Food Collected: " + currentFood.ToString();



    }




}
