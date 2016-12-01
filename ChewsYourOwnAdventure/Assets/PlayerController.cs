using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    bool isWeighing;
    float timeElapsed;

    float runningWeight;
    float lastWeight;
    float runningDeltaWeight;
    int runningWeightSamples;

    public float WeightTime;

    public WeighingPrompt PromptReference;

    void Awake()
    {
        if (PromptReference == null)
        {
            Debug.LogError("PromptReference equals null!");
        }

        //PromptReference.TurnOnPrompt(); //Turn on for testing purposes, delete this code later
    }

    void Update()
    {
        if (isWeighing)
        {
            if (!PromptReference.PromptIsActive())
            {
                if (ScaleController.Instance.Weight > 1 || Input.GetKeyDown(KeyCode.Space))
                {
                    timeElapsed = 0f;
                    runningWeight = 0f;
                    runningDeltaWeight = 0f;
                    runningWeightSamples = 0;
                    GameManager.Instance.InitialPrompt.SetActive(false);
                    PromptReference.TurnOnPrompt();
                }
            }
            else
            {
                timeElapsed += Time.deltaTime;

                runningWeight += ScaleController.Instance.Weight;

                lastWeight = ScaleController.Instance.Weight;

                runningWeightSamples++;

                if (timeElapsed > WeightTime)
                {
                    isWeighing = false;
                    SolveWeight();
                }
            }
        }
    }

    public void StartWeighing()
    {
        isWeighing = true;
    }

    void CalcWeightDelta()
    {
        float d = Mathf.Abs(ScaleController.Instance.Weight - lastWeight);
        runningDeltaWeight += d;
        runningWeight -= Time.deltaTime;
        if (d > 1)
        {
            //Significant change in weight, start over
            StartWeighing();
        }
    }

    void SolveWeight()
    {
        PromptReference.TurnOffPrompt();

        float solvedWeight = runningWeight / runningWeightSamples;

        //message to Game_Manager that weight is solved and send value
        GameManager.Instance.FoodWeighed(solvedWeight);
    }
}
