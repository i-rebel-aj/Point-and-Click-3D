using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    public Transform cameraPosition;
    public List<Node> reachableNodes= new List<Node>();

    [HideInInspector]
    public Collider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnMouseDown()
    {
        Arrive();
    }
    public void Arrive()
    {
        //Set Current Node
        GameManager._instance.currentNode = this;
        //Move Camera
        Camera.main.transform.position = cameraPosition.position;
        Camera.main.transform.rotation = cameraPosition.rotation;
        //Turn off own collider
        if (col != null)
        {
            col.enabled = false;
        }
        //Turn on all reachable node collider only
        foreach (Node node in reachableNodes)
        {
            Debug.Log("Node", node);
            if (node.col != null)
            {
                node.col.enabled = true;
            }
        }
    }
    public void Leave()
    {
        //Turn off all reachable node collider only
        foreach (Node node in reachableNodes)
        {
            Debug.Log("Node", node);
            if (node.col != null)
            {
                node.col.enabled = false;
            }
        }
    }
}
