using System;
using System.Collections.Generic;
using System.Linq;
using ChutesAndLadders.Managers;

namespace ChutesAndLadders
{
    public enum SortType
    {
        SortRandom,
        SortRandomHumanPriority
    }
    
    public static class PlayerTurnSorter
    {
        public static List<(int index, PlayerType type)> Sort(List<(int index, PlayerType type)> playerTypeList, SortType sortType)
        {
            return sortType switch
            {
                SortType.SortRandom => SortRandom(playerTypeList),
                SortType.SortRandomHumanPriority => playerTypeList,
                _ => playerTypeList
            };
        }

        private static List<(int index, PlayerType type)> SortRandom(List<(int index, PlayerType type)> playerTypeList)
        {
            var rng = new Random();  
            
            var n = playerTypeList.Count();  
            while (n > 1) {  
                n--;  
                var k = rng.Next(n + 1);  
                (playerTypeList[k], playerTypeList[n]) = (playerTypeList[n], playerTypeList[k]);
            }

            return playerTypeList;
        }
    }
}

