using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private int playerIndex;
    public Text indexText;
 
    
    void Update()
    {
        playerIndex = gameObject.GetComponent<RankPosition>().index;
        indexText.text = playerIndex + "/11";
        //Debug.Log(playerIndex + "/11");
    }
}
