using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected Characters type;
    private const float CHAR_SPEED = 50f;

    public Characters Type
    {
        get => type;
        set => type = value;
    }

    [SerializeField] private int turnOrder;

    public int TurnOrder
    {
        get => turnOrder;
        set => turnOrder = value;
    }


    //[SerializeField] protected Route Route;
    [SerializeField] protected int actualNodeIdx;
    [SerializeField] protected Node actualNode;

    public enum Characters
    {
        Ghost,
        Player,
        Artificial,
    }

    private float speed = CHAR_SPEED;
    private bool isMoving;
    private int stepsRemaining;

    protected virtual void Init()
    {
        type = Characters.Ghost;
        TurnOrder = -1;
        //actualNode = Route.GetFirstNode();
        actualNodeIdx = actualNode.Id;
    }

    private IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }

        Debug.Log($"Char update steps={stepsRemaining} ismoving={isMoving}");
        isMoving = true;
        while (stepsRemaining > 0)
        {
            //actualNode = Route.GetNextNode(actualNode);
            actualNodeIdx = actualNode.Id;
            var nextPos = actualNode.GetPosition();

            while (MoveToNextNode(nextPos))
            {
                yield return null;
            }
            stepsRemaining--;
        }

        yield return new WaitForSeconds(0.1f);


        if (actualNode.Type != Node.NodeType.TypeEmpty)
        {
            switch (actualNode.Type)
            {
                case Node.NodeType.TypeLadder:
                {
                    Debug.Log("Happy noises");
                    actualNode = actualNode.Connected;
                    actualNodeIdx = actualNode.Id;
                    var nextPos = actualNode.GetPosition();
                    while (MoveToNextNode(nextPos))
                    {
                        yield return null;
                    }

                    break;
                }
                case Node.NodeType.TypeChute:
                {
                    Debug.Log("Sad noises");
                    actualNode = actualNode.Connected;
                    actualNodeIdx = actualNode.Id;
                    var nextPos = actualNode.GetPosition();
                    while (MoveToNextNode(nextPos))
                    {
                        yield return null;
                    }
                    break;
                }
                case Node.NodeType.TypeGoal:
                {
                    Debug.Log("Winner");
                    break;
                }
                case Node.NodeType.TypeEmpty:
                default:
                    break;
            }
        }
        isMoving = false;
    }

    private bool MoveToNextNode(Vector3 nextPos)
    {
        return nextPos !=
               (transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime));
    }

    // public bool MakeTurn(int stepsToMove)
    // {
    //     stepsRemaining = stepsToMove;
    //     if (Route.DoesNodeExist(actualNode, stepsToMove))
    //     {
    //         //StartCoroutine(Move());
    //         return true;
    //     }
    //     else
    //     {
    //         print("Number is to High");
    //         return false;
    //     }
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            stepsRemaining = Random.Range(1, 21);
            //Debug.Log($"Char update steps={stepsRemaining} ismoving={isMoving}");
            StartCoroutine(Move());
        }
    }
}