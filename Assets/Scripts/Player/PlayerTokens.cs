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
}