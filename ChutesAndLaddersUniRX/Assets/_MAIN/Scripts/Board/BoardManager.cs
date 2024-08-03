namespace ChutesAndLadders.Managers
{
    public partial class BoardManager
    {
        public enum GameStates
        {
            WAITING,
            ROLL_DICE,
            SWITCH_ACTIVE_PLAYER,
        }
        public GameStates gameState;
        
    }
}
