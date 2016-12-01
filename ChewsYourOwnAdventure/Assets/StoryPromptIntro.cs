using UnityEngine;
using System.Collections;

public class StoryPromptIntro : MonoBehaviour
{
    public GameObject[] TextObjects;

	void Start ()
    {
        StartCoroutine(ShowTextGroups());
	}
	
	IEnumerator ShowTextGroups()
    {
        int i = 0;

        while (i < TextObjects.Length)
        {
            TextObjects[i].SetActive(true);
            yield return new WaitForSeconds(3f);
            i++;
        }
    }
}
