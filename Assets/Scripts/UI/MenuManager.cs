using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject loadingScene;
    public Slider slider;


    public void ToGame()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("SampleScene");

        while (!operation.isDone)
        {
            loadingScene.SetActive(true);


            float progress = Mathf.Clamp01(operation.progress/ 0.9f);
            slider.value = progress;


            yield return null;
        }
    }






}
