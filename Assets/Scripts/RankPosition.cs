using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RankPosition : MonoBehaviour
{
    
    public BotPosition[] allBots;
    public BotPosition[] botOrder;
    public BotPosition player;
    public int index = 11;
    
    
    // Start is called before the first frame update
    public void Start()
    {
        botOrder = new BotPosition[allBots.Length];
        InvokeRepeating("ManualUpdate", 0.5f, 0.5f);
    }

    // Update is called once per frame
    public void ManualUpdate()
    {
        allBots[10] = player;
        foreach (BotPosition bot in allBots)
        {
            
            botOrder[bot.GetBotPosition(allBots) - 1] = bot;
            
            
            for(int i = 0; i < botOrder.Length; i++)
            {
                if(botOrder[i] == player)
                {
                    index = i;
                    break;
                }
            }
            index = (11 - index);
            //Debug.Log((11 - index) +  "/11");
        }
    }
}
