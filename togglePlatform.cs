using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togglePlatform : MonoBehaviour
{
    [SerializeField]
    private Transform islandTransform;

    private Vector3 startPos;

    void Start()
    {
        startPos = this.transform.position;
    }

    void Update()
    {
        if (this.transform.position.y <= islandTransform.position.y)
        {
            this.transform.position = startPos;
        }
    }
}
