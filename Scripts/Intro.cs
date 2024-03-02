using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
	IEnumerator EndingIn()
	{
		yield return new WaitForSeconds(14f);
		StartCoroutine(LoadSceneAsync());
	}

    void Update()
    {
        StartCoroutine(EndingIn());
    }
	
	IEnumerator LoadSceneAsync()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(1);
		while (!operation.isDone)
		{
			float progressValue = Mathf.Clamp01(operation.progress / 0.6f);
			yield return null;
		}
	}
}
