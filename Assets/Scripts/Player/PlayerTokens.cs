using System.Collections.Generic;
using UnityEngine;

public class PlayerTokens : MonoBehaviour
{
    PlayerMan pm;

    public List<TokenMan> tokens = new List<TokenMan>();

    public void SetParams(PlayerMan pm)
    {
        this.pm = pm;

        TokenConstructor.createTokenEvent += AddToken;
    }

    public void AddToken(TokenMan tm)
    {
        tokens.Add(tm);

        tm.deathEvent += RemoveToken;
    }

    public void RemoveToken(EntityMan em)
    {
        tokens.Remove((TokenMan) em);
    }

    public void DestroyTokens()
    {
        for (int i = tokens.Count - 1; i >= 0; i--)
        {
            TokenMan tm = tokens[i];
            RemoveToken(tm);
            Destroy(tm.gameObject);
        }
    }
}