using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPosition : MonoBehaviour
{

    public Transform finishLine;



    public float GetDistance() 
    {
        return (transform.position - finishLine.transform.position).magnitude;
    }

    public int GetBotPosition(BotPosition[] allBots)
    {
        float distance = GetDistance();
        int position = 1;
        foreach (BotPosition bot in allBots)
        {
            if(bot.GetDistance() > distance)
            position++;
        }
        return position;
        //Debug.Log(position);
    }

    private void Update() {
        //Debug.Log(position);
    }

}
