using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    //Load Screen Game Objects
    public GameObject loadingScene;
    public Slider slider;

    //Pause Screen Game Objects
    public GameObject PausePanel;
    public GameObject PauseButton;
    public GameObject UnPauseButton;


    private void Awake()
    {
        PausePanel.SetActive(false);
    }


    #region Scene Swap method
    //This method will take an input of a scene name then take you to that scene
    public void ToScene(string scene)
    {
        StartCoroutine(LoadAsynchronously(scene));
    }
    #endregion


    #region LoadingScreen Method
    //This scene can be called to pull up the loading screen while loading a scene called from the "ToScene" method
    IEnumerator LoadAsynchronously(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        while (!operation.isDone)
        {
            loadingScene.SetActive(true);


            float progress = Mathf.Clamp01(operation.progress/ 0.9f);
            slider.value = progress;


            yield return null;
        }
    }
    #endregion


    #region Pause Game Method
    //Pause the game bet setting the time scale to 0 so all time activites 
    //Activates the pause menu pannel to pull up a new UI
    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
    }
    #endregion


    #region Un Pause Method
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
    }
    #endregion





}
