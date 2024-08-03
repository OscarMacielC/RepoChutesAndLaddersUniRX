using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private Node[] nodes;
    [SerializeField] private List<Transform> nodeList = new List<Transform>();

    public List<Transform> NodeList
    {
        get => nodeList;
        set => nodeList = value;
    }

    private Node _auxNode;

    private const int STARTING_NODE = 0;
    private const int NEXT_NODE = 1;

    private void Start()
    {
        FillNodesID();
        FillNodesTypes();
    }

    private void FillNodesID()
    {
        nodeList.Clear();
        nodes = GetComponentsInChildren<Node>();


        foreach (var node in nodes.Select((value, i) => new { i, value }))
        {
#if UNITY_EDITOR
            if (node.i > STARTING_NODE && !Application.isPlaying)
            {
                node.value.SetPrevious(_auxNode);
                Handles.color = new Color(1, 1, 0, 0.5f);
                Handles.DrawLine(_auxNode.GetPosition(), node.value.GetPosition(), 1f);
            }
#endif
            nodeList.Add(node.value.GetNodeTransform());
            var value = node.value;
            node.value.SetIdNumber(node.i);
            _auxNode = node.value;
        }
    }

    private void FillNodesTypes()
    {
        foreach (var node in nodes)
        {
            node.SetNodeType();
        }
    }

    private void OnDrawGizmosSelected()
    {
        FillNodesID();
        FillNodesTypes();
    }

    public Node GetFirstNode()
    {
        return nodes[STARTING_NODE];
    }
    
    public int GetLastNodeId()
    {
        return nodeList.Count;
    }

    public Node GetNextNode(Node node)
    {
        try
        {
            return nodes[node.Id + NEXT_NODE];
        }
        catch
        {
            return nodes[node.Id];
        }
    }

    public Node DoesNodeExist(Node node, int steps)
    {
        try
        {
            return nodes[node.Id + steps];
        }
        catch
        {
            return null;
        }
    }
}