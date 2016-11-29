using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    bool isWeighing;
    float timeElapsed;

    float runningWeight;
    int runningWeightSamples;

    public float WeightTime;

    public WeighingPrompt PromptReference;

    void Awake()
    {
        if (PromptReference == null)
        {
            Debug.LogError("PromptReference equals null!");
        }

        PromptReference.TurnOnPrompt(); //Turn on for testing purposes, delete this code later
    }

    void Update()
    {
        if (isWeighing)
        {
            timeElapsed += Time.deltaTime;

            runningWeight += ScaleController.Instance.Weight;
            runningWeightSamples++;

            if (timeElapsed > WeightTime)
            {
                isWeighing = false;
                SolveWeight();
            }
        }
    }

    public void StartWeighing()
    {
        timeElapsed = 0f;
        runningWeight = 0f;
        runningWeightSamples = 0;
        isWeighing = true;
        PromptReference.TurnOnPrompt();
    }

    void SolveWeight()
    {
        PromptReference.TurnOffPrompt();

        float solvedWeight = runningWeight / runningWeightSamples;

        //message to Game_Manager that weight is solved and send value
    }
}
