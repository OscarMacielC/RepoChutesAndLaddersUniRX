using System.Linq;
using UnityEngine;

public class CharacterInitializer : MonoBehaviour
{
    [SerializeField] private Transform[] _initPositions;
    private int _initialized = 0;
    private const int SELF = 0;
    
    private void Awake()
    {
        _initPositions = GetComponentsInChildren<Transform>();
        _initPositions = _initPositions.Skip(1).ToArray();  
        _initialized = 0;
    }

    private bool EnoughCharacters(int num)
    {
        return num <= _initPositions.Length;
    }

    public Vector3 GetNextPosition()
    {
        if(!EnoughCharacters(_initialized))
            return Vector3.negativeInfinity;
        var initPosition = _initPositions[_initialized];
        _initialized++;
        return initPosition.position;
    }
    
    public Vector3 GetInitialPosition()
    {
        if(!EnoughCharacters(_initialized))
            return Vector3.negativeInfinity;
        var initPosition = _initPositions[_initialized];
        _initialized++;
        return initPosition.position;
    }
    
    public Vector3 GetNPosition(int n)
    {
        var initPosition = _initPositions[n];
        return initPosition.position;
    }
    
}
