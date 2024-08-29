using System.IO;
using UnityEngine;

[CreateAssetMenu (fileName = "BoardConfiguration", menuName = "ScriptableObjects/BoardConfiguration")]
public class BoardConfiguration : ScriptableObject
{
    #region Fields

    [SerializeField]
    private GameObject Route;
    

    #endregion
}
