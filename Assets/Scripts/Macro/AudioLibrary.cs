using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public static class AudioLibrary
{
    public static float AUDIO_VOLUME = .5f;


    public static Dictionary<CommandID, AudioClip> audioDict = new Dictionary<CommandID, AudioClip>()
    {
        { CommandID.Attack, Resources.Load<AudioClip>("Audio/Attack") },
        { CommandID.Defend, Resources.Load<AudioClip>("Audio/Defend") },
        { CommandID.Heal, Resources.Load<AudioClip>("Audio/Heal") },
    };
}
