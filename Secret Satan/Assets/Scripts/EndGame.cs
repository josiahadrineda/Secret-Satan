using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public SceneFlow sceneFlow;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            sceneFlow.Invoke("ReturnToMenu", 0f);
        }
    }
}
