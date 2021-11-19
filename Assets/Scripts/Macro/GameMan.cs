using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class GameMan : MonoBehaviour
{
    public PlayerMan PlayerMan;
    public FoeMan FoeMan;

    public TokenGameSM CardGameSM;
    public StateTracker StateTracker;

    public InputController InputController;
    public ProgressionMan ProgressionMan;
    
    private void Awake()
    {
        if (ServiceLocator.HasService<GameMan>())
        {
            Destroy(gameObject);
        }
        else
        {
            ServiceLocator.Register<GameMan>(this);
        }
    }

    private void Start()
    {
        //SetGameParams(PlayerConstructor.GetPlayerInfo(PlayerID.Normal));
    }

    public void SetGameParams(PlayerInfo playerInfo)
    {
        GameObject playerManObject = PlayerConstructor.CreatePlayer(playerInfo.playerID, ServiceLocator.GetService<GameUIMan>().PlayerUI.canvasObj.transform);
        PlayerMan = playerManObject.GetComponent<PlayerMan>();

        PlayerMan.SetParams((EntityInfo)playerInfo);
    }
}
