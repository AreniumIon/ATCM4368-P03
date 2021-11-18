using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SetGameParams(PlayerInfo playerInfo)
    {
        GameObject playerManObject = PlayerConstructor.CreatePlayer(playerInfo.playerID, transform, GameConstants.PLAYER_POS);
        PlayerMan = playerManObject.GetComponent<PlayerMan>();

        PlayerMan.SetParams((EntityInfo)playerInfo);
    }
}
