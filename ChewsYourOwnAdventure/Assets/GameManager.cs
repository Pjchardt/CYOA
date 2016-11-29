using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    static GameManager Instance;

    float FoodStartWeight;
    float FoodCurrentWeight;

    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        //Show prompt to place food on scale
    }

    public void FoodWeighed(float w)
    {
        FoodStartWeight = w;
    }
}
