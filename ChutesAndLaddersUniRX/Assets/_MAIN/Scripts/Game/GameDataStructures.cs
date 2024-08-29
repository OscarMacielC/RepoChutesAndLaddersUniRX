using System.Collections.Generic;

namespace ChutesAndLadders.Game
{
    public class Turn
    {
        public List<IMovement> MovementsList = new();

        public void AddMovement(IMovement newMovement)
        {
            MovementsList.Add(newMovement);
        }
    }

    public interface IMovement
    {
    }

    public struct RollDiceMovement : IMovement
    {
        public int RollResult { get; } 
            
        public RollDiceMovement(int rollResult)
        {
            RollResult = rollResult;
        }
    }

    public struct MovePlayerMovement : IMovement
    {
        public int Moves { get; } 
            
        public MovePlayerMovement(int moves)
        {
            Moves = moves;
        }
    }
}