using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Days left progress", menuName = "Levels/Days")]
public class ProgressAsset : ScriptableObject
{
    private int daysLeft0 = 15;
    private int daysLeft1 = 15;
    private int daysLeft2 = 15;

    public int daysPassed = 0;

    public event Action DayOver;
    public Action FirstBreak;  //when shia turns into a troll
    public Action SecondBreak; //when

    public int DaysPassed
    {
        get { return daysPassed; }
        set
        {
            daysPassed = value;

            if (DayOver != null)
            {
                DayOver();
            }
        }
    }

    public void ConsumeDay()
    {
        if (daysLeft0 > 0)
        {
            daysLeft0--;
        }
        else
        {
            if (daysLeft1 > 0)
            {
                daysLeft1--;
            }
            else
            {
                if (daysLeft2 > 0)
                {
                    daysLeft2--;
                }
                else
                {
                    //shia die
                    return;
                }
            }
        }
    }

    public void PayShard()
    {
        if (daysLeft0 > 0)
        {
            daysLeft0++;
        }
        else
        {
            if (daysLeft1 > 0)
            {
                daysLeft1++;
            }
            else
            {
                if (daysLeft2 > 0)
                {
                    daysLeft2++;
                }
            }
        }
    }

}
