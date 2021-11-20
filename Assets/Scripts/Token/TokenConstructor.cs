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

    public static GameObject CreateToken(TokenID newTokenID, Transform parent)
    {
        GameObject newToken = GameObject.Instantiate(tokenPrefab, parent, false);
        TokenInfo tokenInfo = tokenDict[newTokenID];

        // Token
        TokenMan tm = newToken.GetComponent<TokenMan>();
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
