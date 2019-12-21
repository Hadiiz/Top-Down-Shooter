using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Data : MonoBehaviour
{
    public static bool move = true;

    public static bool newGame = true;

    public static bool trainingLvl = true;

    public static bool lvl1 = false;

    public static bool lvl2 = false;

    public static bool lvl3 = false;

    //////////////////////////////////////////////////////////////////////////////////////////
    public static float playerHealth = 500;

    public static float tpTime = 5f;

    public static float playerDamage = 50;

    public static bool teleport = true;

    //////////////////////////////////////////////////////////////////////////////////////////

    public static float alienBossHealth = 5000;
    public static float skeletonBossHealth = 7000;


    public static void Load()
    {
        Debug.Log("start");
        if (SaveSystem.LoadData() != null)
        {
            DataSaved data = SaveSystem.LoadData();
            bool[] checkers = data.GetBooleans();
            float[] stats = data.GetStats();

            move = checkers[0];
            newGame = checkers[1];
            trainingLvl = checkers[2];
            lvl1 = checkers[3];
            lvl2 = checkers[4];
            lvl3 = checkers[5];
            teleport = checkers[6];

            playerHealth = stats[0];
            tpTime = stats[1];
            playerDamage = stats[2];
            alienBossHealth = stats[3];
            skeletonBossHealth = stats[4];

        }
        else
        {
            Debug.Log("not not");
        }
    }




}
