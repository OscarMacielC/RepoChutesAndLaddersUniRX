using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Node))]
public class Node : MonoBehaviour
{
    [SerializeField] private int id;

    public int Id
    {
        get => id;
        set => id = value;
    }

    [SerializeField] private TextMeshProUGUI nodeText;
    private Node _previous;
    [SerializeField] private Node connected;

    public Node Connected
    {
        get => connected;
        set => connected = value;
    }

    [SerializeField] private NodeType type;

    public NodeType Type
    {
        get => type;
        set => type = value;
    }

    private const string START_TEXT = "Start";
    private const int STARTING_NODE = 0;

    public enum NodeType
    {
        TypeEmpty,
        TypeLadder,
        TypeChute,
        TypeGoal,
    }

    public void Awake()
    {
        Reset();
    }

    private void Reset()
    {
        id = -1;
        if (nodeText == null)
            nodeText = GetComponentInChildren<TextMeshProUGUI>();
        _previous = null;
    }

    public Transform GetNodeTransform()
    {
        return transform;
    }

    public void SetIdNumber(int nodeID)
    {
        this.id = nodeID;
        nodeText.SetText(nodeID != STARTING_NODE ? nodeID.ToString() : START_TEXT, nodeText.fontSize = 0.3f);
    }

    public void SetPrevious(Node node)
    {
        _previous = node;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetNodeType()
    {
        if (connected == null) return;
        if (type != NodeType.TypeEmpty) return;
        type = connected.id >= id ? NodeType.TypeLadder : NodeType.TypeChute;
    }

    private void OnDrawGizmosSelected()
    {
        switch (type)
        {
            case NodeType.TypeLadder:
                Handles.color = new Color(0, 1, 0, 0.4f);
                Handles.DrawLine(GetPosition(), connected.GetPosition(), 4f);
                Handles.DrawSolidDisc(GetPosition(), new Vector3(0, 1, 0), 4f);
                break;
            case NodeType.TypeChute:
                Handles.color = new Color(1, 0, 0, 0.4f);
                Handles.DrawLine(GetPosition(), connected.GetPosition(), 4f);
                Handles.DrawSolidDisc(GetPosition(), new Vector3(0, 1, 0), 4f);
                break;
            case NodeType.TypeGoal:
                Handles.color = new Color(0f, 1f, 1, 0.4f);
                Handles.DrawSolidDisc(GetPosition(), new Vector3(0, 1, 0), 4f);
                break;
            case NodeType.TypeEmpty:
            default: break;
        }
    }
}