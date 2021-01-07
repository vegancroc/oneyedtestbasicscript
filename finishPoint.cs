using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class finishPoint : MonoBehaviour
{
    [SerializeField]
    private string playerTag;

    [SerializeField]
    private int nextSceneIndex;

    [SerializeField]
    private string data;

    private bool isFinished;

    void Start()
    {
        List<int> levels = saveSystem.ReadNumbersInLine(0);

        string readData = saveSystem.ReadNumbersInLineString(0);

        if (levels.Contains(SceneManager.GetActiveScene().buildIndex))
        {
            data = readData;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == playerTag)
        {
            saveSystem.data1 = data;
            saveSystem.CreateSaveFile();
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

}
