using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;
using System;

public static class TokenConstructor
{
    static GameObject tokenPrefab = Resources.Load<GameObject>("Prefabs/Token");

    static Dictionary<TokenID, TokenInfo> tokenDict = new Dictionary<TokenID, TokenInfo>()
    {
        {TokenID.Attack, Resources.Load<TokenInfo>("GameData/Data/TokenInfo/Attack Token")},
        {TokenID.Defend, Resources.Load<TokenInfo>("GameData/Data/TokenInfo/Defend Token")},
        {TokenID.Heal, Resources.Load<TokenInfo>("GameData/Data/TokenInfo/Heal Token")},
    };

    public static TokenInfo GetTokenInfo(TokenID tokenID)
    {
        return tokenDict[tokenID];
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
        TokenID newTokenID = (TokenID) choice;

        return CreateToken(newTokenID, parent);
    }

    public static GameObject CreateToken(TokenID newTokenID, Transform parent)
    {
        GameObject newToken = GameObject.Instantiate(tokenPrefab, parent, false);
        TokenMan tm = newToken.GetComponent<TokenMan>();
        TokenInfo tokenInfo = tokenDict[newTokenID];

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
