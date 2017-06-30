using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

    public static List<int> ScoreCumulative (List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        int Lenght = rolls.Count;
        bool lastRound = false;
        int totalCum = Lenght;
        for (int i = 0; i < (Lenght-1); i += 2)
        {
            if (totalCum >= 19)
            {
                lastRound = true;
            }
            if (rolls[i] == 10)
            {
                if (i + 2 <= Lenght - 1)
                {
                    frameList.Add (rolls[i] + rolls[i + 1] + rolls[i + 2]);
                }
                totalCum++;
                i--;
            }
            else
            {
                if ((rolls[i] + rolls[i + 1]) >= 10)
                {
                    if (i + 2 <= Lenght - 1)
                    {
                        frameList.Add (rolls[i] + rolls[i + 1] + rolls[i + 2]);
                    }
                }
                else
                {
                    frameList.Add(rolls[i] + rolls[i + 1]);
                }
            }
        }
         if (lastRound)
        {
            if (frameList.Count > 10)
            {
                frameList.RemoveAt(10);
            }
            lastRound = false;

        }
        return frameList;
    }

}
