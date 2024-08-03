using UnityEngine;

namespace ChutesAndLadders.Managers
{
    public partial class BoardController : MonoBehaviour
    {
        [SerializeField] private Route route;
        
        public Node GetFirstNode()
        {
            return route.GetFirstNode();
        }

        
        
    }
}
