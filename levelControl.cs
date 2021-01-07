using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelControl : MonoBehaviour
{
    public GameObject[] levelButtons;

    void Start()
    {
        if (!saveSystem.FileCheck())
        {
            saveSystem.data1 = "0";
            saveSystem.CreateSaveFile();
        }
    }

    void Update()
    { 
        List<int> levels = saveSystem.ReadNumbersInLine(0);

        if (levels.Contains(0))
        {
            SetButton(levelButtons[0], true);
            SetAnim(levelButtons[0], true);
            SetText(levelButtons[0], true);
        }

        if (levels.Contains(1))
        {
            SetButton(levelButtons[1], true);
            SetAnim(levelButtons[1], true);
            SetText(levelButtons[1], true);
        }

        if (levels.Contains(2))
        { 
            SetButton(levelButtons[2], true);
            SetAnim(levelButtons[2], true);
            SetText(levelButtons[2], true);
        }

    }


    void SetButton(GameObject obj, bool value)
    {
        obj.GetComponent<Button>().enabled = value;
    }

    void SetAnim(GameObject obj, bool value)
    {
        Animator anim = obj.GetComponentInParent<Animator>();

        if (anim != null)
        { 
            anim.SetBool("unlocked", true);
        }
    }

    void SetText(GameObject obj, bool value)
    {
        obj.GetComponent<Text>().enabled = value;
    }

    public void resetLevels()
    {
        saveSystem.data1 = "0";
        saveSystem.CreateSaveFile();

        SceneManager.LoadScene(0);
    }

}
