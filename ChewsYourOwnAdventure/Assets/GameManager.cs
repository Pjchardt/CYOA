using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    public enum GameState { InitialState, ShowingText, WeightingToRemove, WaitingToBePlaced, Weighing}
    [NonSerialized]
    public GameState currentState;

    float FoodStartWeight;
    float FoodCurrentWeight;

    public GameObject InitialPrompt;
    public GameObject PromptOne;
    public GameObject EatPromptOne;
    public GameObject PromptTwo;
    public GameObject EatPromptTwo;

    public PlayerController PlayerRef;

    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        //Show prompt to place food on scale
        InitialPrompt.SetActive(true);
        currentState = GameState.InitialState;

        PlayerRef.StartWeighing();
    }

    void Update()
    {
        if (currentState == GameState.WeightingToRemove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EatPromptOne.SetActive(false);
                currentState = GameState.Weighing;
                PlayerRef.StartWeighing();
            }
        }
    }

    public void FoodWeighed(float w)
    {
        if (currentState == GameState.InitialState)
        {
            FoodStartWeight = w;
            FoodCurrentWeight = FoodStartWeight;

            PromptOne.SetActive(true);

            StartCoroutine(WaitToShowPrompt(PromptOne, EatPromptOne));

            currentState = GameState.ShowingText;
        }
        else if (currentState == GameState.Weighing)
        {
            PromptTwo.SetActive(true);

            StartCoroutine(WaitToShowPrompt(PromptTwo, EatPromptTwo));

            currentState = GameState.ShowingText;
        }
    }

    IEnumerator WaitToShowPrompt(GameObject prompt, GameObject eatPrompt)
    {
        yield return new WaitForSeconds(9f);
        prompt.SetActive(false);
        eatPrompt.SetActive(true);

        currentState = GameState.WeightingToRemove;
    }
    
}
