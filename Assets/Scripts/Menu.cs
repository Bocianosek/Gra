using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool isCursorVisible = true;

    private void Start()
    {
        Cursor.visible = isCursorVisible;
    }

    public void LoadGame(int index)
    {
        SceneManager.LoadScene(index);
        isCursorVisible = false;
        Cursor.visible = isCursorVisible;
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0) 
        {
            isCursorVisible = true;
            Cursor.visible = isCursorVisible;
        }
    }
}
