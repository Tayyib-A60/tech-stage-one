using System;
using System.Collections.Generic;
using System.Linq;

namespace SocksLaundryLib
{
    public class ClassLib
    {

        //Do not delete or edit this method, you can only modify the block
        public int GetMaximumPairOfSocks(int noOfWashes, int[] cleanPile, int[] dirtyPile)
        {
            //You can edit from here down
            var allSocksPile = new Dictionary<int, int[]>();

            for(int i = 0; i < cleanPile.Length; i++) {

                if(allSocksPile.ContainsKey(cleanPile[i])) {
                    allSocksPile.TryGetValue(cleanPile[i], out var currentCount);
                    currentCount[0] += 1;
                    allSocksPile.Remove(cleanPile[i]);
                    allSocksPile.Add(cleanPile[i], currentCount);
                } else {
                    var cleanDirty = new int[2] {0,0};
                    cleanDirty[0] += 1;
                    allSocksPile.Add(cleanPile[i], cleanDirty);
                }
            }
            
            for(int i = 0; i < dirtyPile.Length; i++) {

                if(allSocksPile.ContainsKey(dirtyPile[i])) {
                    allSocksPile.TryGetValue(dirtyPile[i], out var currentCount);
                    currentCount[1] += 1;
                    allSocksPile.Remove(dirtyPile[i]);
                    allSocksPile.Add(dirtyPile[i], currentCount);
                } else {
                    var cleanDirty = new int[2] {0,0};
                    cleanDirty[1] += 1;
                    allSocksPile.Add(dirtyPile[i], cleanDirty);
                }

            }
            
            for(int i = 0; i < noOfWashes; i++) {
                var matched = allSocksPile.Where(sock => sock.Value[0]%2 != 0 && sock.Value[1] > 0).Count() > 0;
                if(matched) {
                    var firstFit = allSocksPile.FirstOrDefault(sock => sock.Value[0]%2 != 0 && sock.Value[1] > 0);
                    if(firstFit.Key > 0) {
                        allSocksPile.TryGetValue(firstFit.Key, out var currentCount);
                        currentCount[0] += 1;
                        currentCount[1] -= 1;
                        allSocksPile.Remove(firstFit.Key);
                        allSocksPile.Add(firstFit.Key, currentCount);
                    }
                } else {
                    var firstFit = allSocksPile.FirstOrDefault(sock => sock.Value[0]%2 == 0 && sock.Value[1] >= 2 );
                    if(firstFit.Key > 0) {
                        allSocksPile.TryGetValue(firstFit.Key, out var currentCount);
                        currentCount[0] += 1;
                        currentCount[1] -= 1;
                        allSocksPile.Remove(firstFit.Key);
                        allSocksPile.Add(firstFit.Key, currentCount);
                    }
                }
            }

            int result = 0;
            foreach (var sock in allSocksPile)
            {
                result += sock.Value[0]/2;
            }

            return result;
        }

        /**
         * You can create various helper methods
         * */
    }
}
