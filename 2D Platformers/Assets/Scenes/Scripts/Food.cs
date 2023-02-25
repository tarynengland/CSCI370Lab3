using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //assignable points based on each item
    public int points;

    // allows food to rotate
    [SerializeField] private Vector3 _rotation;

    // increases points based on how much the object is worth
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        print("Entered..");
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            FoodCounter.instance.IncreaseFood(points);
        }
    }


    // rotates food
    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    }
}
