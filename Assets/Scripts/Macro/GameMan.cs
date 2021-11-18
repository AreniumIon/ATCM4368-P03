using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class GameMan : MonoBehaviour
{
    public static GameMan i;

    // SetParams() on new game
    public PlayerMan PlayerMan;

    public FoeMan FoeMan;

    private void Awake()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetGameParams(PlayerConstructor.GetPlayerInfo(PlayerID.Normal));
    }

    public void SetGameParams(PlayerInfo playerInfo)
    {
        GameObject playerManObject = PlayerConstructor.CreatePlayer(playerInfo.playerID, GameCanvasMan.i.PlayerCanvas.transform);
        PlayerMan = playerManObject.GetComponent<PlayerMan>();

        PlayerMan.SetParams((EntityInfo)playerInfo);

        Debug.Log("finished setparams");
    }
}
