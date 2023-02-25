using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int points;


    [SerializeField] private Vector3 _rotation;


    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        print("Entered..");
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            FoodCounter.instance.IncreaseFood(points);
        }
    }



    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    }
}
