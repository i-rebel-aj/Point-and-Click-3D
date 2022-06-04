using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public Node currentNode;
    public static GameManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            Prop currentProp = currentNode.GetComponent<Prop>();
            currentProp.loc.Arrive();
        }
    }
}
