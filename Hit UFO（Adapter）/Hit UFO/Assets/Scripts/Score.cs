using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    int points;

    public Score()
    {
        points = 0;
    }

    public void Record(Disk disk)
    {
        points += disk.points;
    }

    public int GetPoints()
    {
        return points;
    }
    public void Reset()
    {
        points = 0;
    }
}