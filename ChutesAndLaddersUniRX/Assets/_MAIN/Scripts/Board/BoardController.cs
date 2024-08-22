using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace ChutesAndLadders.Managers
{
    public partial class BoardController : MonoBehaviour
    {
        [SerializeField] private GameObject route;

        public Node GetFirstNode()
        {
            return nodes[STARTING_NODE];
        }

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
            nodes = route.GetComponentsInChildren<Node>();


            foreach (var node in nodes.Select((value, i) => new { i, value }))
            {
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
}