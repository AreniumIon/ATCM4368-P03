using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;
using System;

public static class TokenConstructor
{
    static GameObject tokenPrefab = Resources.Load<GameObject>("Prefabs/Token");

    static Dictionary<CommandID, TokenInfo> tokenDict = new Dictionary<CommandID, TokenInfo>()
    {
        {CommandID.Attack, Resources.Load<TokenInfo>("GameData/Data/TokenInfo/Attack Token")},
        {CommandID.Defend, Resources.Load<TokenInfo>("GameData/Data/TokenInfo/Defend Token")},
        {CommandID.Heal, Resources.Load<TokenInfo>("GameData/Data/TokenInfo/Heal Token")},
    };

    public static TokenInfo GetTokenInfo(CommandID commandID)
    {
        return tokenDict[commandID];
    }

    // Called in SetupBattleState and PlayerTurnState
    public static void CreatePlayerToken()
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();
        GameUIMan gameUIMan = ServiceLocator.GetService<GameUIMan>();

        GameObject tokenManObj = CreateRandomToken(gameUIMan.PlayerTurnUI.tokenParent);
        TokenMan tokenMan = tokenManObj.GetComponent<TokenMan>();
    }

    public static GameObject CreateRandomToken(Transform parent)
    {
        int choice = UnityEngine.Random.Range(0, tokenDict.Count);
        CommandID newCommandID = (CommandID) choice;

        return CreateToken(newCommandID, parent);
    }

    public static GameObject CreateToken(CommandID newCommandID, Transform parent)
    {
        GameObject newToken = GameObject.Instantiate(tokenPrefab, parent, false);
        TokenMan tm = newToken.GetComponent<TokenMan>();
        TokenInfo tokenInfo = tokenDict[newCommandID];

        // Token
        tm.SetParams(tokenInfo);

        // Events
        CreateTokenEvent(tm);

        return newToken;
    }

    // Events
    public static event Action<TokenMan> createTokenEvent;
    public static void CreateTokenEvent(TokenMan newToken)
    {
        if (createTokenEvent != null)
            createTokenEvent(newToken);
    }

    public static void ClearEvents()
    {
        createTokenEvent = null;
    }
}
