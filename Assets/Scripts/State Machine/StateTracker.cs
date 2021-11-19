using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateTracker : MonoBehaviour
{
    // Use by attaching to GameObject that has StateMachine component.
    // StateTracker keeps list of states that StateMachine has used for access by other components.

    [SerializeField] StateMachine stateMachine;

    Dictionary<Type, object> states = new Dictionary<Type, object>();

    private void Start()
    {
        stateMachine.ChangeStateEvent += TrackState;
    }

    public void TrackState(State state)
    {
        if (!states.ContainsKey(state.GetType()))
        {
            states.Add(state.GetType(), state);
        }
    }

    public T GetState<T>()
    {
        Debug.Assert(states.ContainsKey(typeof(T)));
        
        return (T) states[typeof(T)];
    }

}
