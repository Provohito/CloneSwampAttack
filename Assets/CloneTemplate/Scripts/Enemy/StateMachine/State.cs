using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transition;

    protected Player Target { get; private set; }

    public void Enter(Player target)
    {
        if(enabled == false)
        {
            Target = target;
            enabled = true;

            foreach (var transition in _transition)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if(enabled == true)
        {
            foreach (var transition in _transition)
                transition.enabled = false;

            enabled = false;
        }
    }

    public State GetNext()
    {
        foreach (var transition in _transition)
        {
            if(transition.NeedTransit)
                return transition.TargetState;
        }
        return null;
    }


}
