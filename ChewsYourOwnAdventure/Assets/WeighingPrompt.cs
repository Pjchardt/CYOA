using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeighingPrompt : MonoBehaviour
{
    public Text TextReference;
    int currentIndex;

    void Awake()
    {
        TextReference.gameObject.SetActive(false);
    }

    public void TurnOnPrompt()
    {
        TextReference.gameObject.SetActive(true);
        currentIndex = 0;
        StartCoroutine(ShowingPrompt());
    }

    IEnumerator ShowingPrompt()
    {
        currentIndex = ++currentIndex % 4;
        string s = "";
        for (int i = 0; i < currentIndex; i++)
        {
            s += ".";
        }
        TextReference.text = "Weighing" + s;

        yield return new WaitForSeconds(.5f);
        StartCoroutine(ShowingPrompt());
    }

    public void TurnOffPrompt()
    {
        StopAllCoroutines();
        TextReference.gameObject.SetActive(false);
    }
}
