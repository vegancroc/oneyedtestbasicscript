using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject levelMenu;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private float openMenuTime;

    public void loadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void openLevelSelectMenu()
    {
        Invoke("levelSelect", openMenuTime); 
    }

    public void openMainMenu()
    {
        Invoke("menu", openMenuTime);
    }

    public void closeGame()
    {
        Invoke("quit", openMenuTime);
    }

    void levelSelect()
    {
        levelMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    void menu()
    {
        mainMenu.gameObject.SetActive(true);
        levelMenu.gameObject.SetActive(false);
    }

    void quit()
    {
        Application.Quit();
    }
}
