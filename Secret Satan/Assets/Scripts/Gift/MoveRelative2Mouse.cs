using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MoveRelative2Mouse : MonoBehaviour
{

    public Vector3 pz;
    public Vector3 StartPos;

    public float moveModifier = 1f;

    void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        Vector3 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float xChange;
        if (pz.x > 1f)
        {
            xChange = moveModifier;
        }
        else if (pz.x < 0f)
        {
            xChange = 0;
        }
        else
        {
            xChange = pz.x * moveModifier;
        }

        float yChange;
        if (pz.y > 1f)
        {
            yChange = moveModifier;
        }
        else if (pz.y < 0f)
        {
            yChange = 0;
        }
        else
        {
            yChange = pz.y * moveModifier;
        }

        transform.position = new Vector3(StartPos.x + xChange, StartPos.y + yChange, transform.position.z);
    }
}