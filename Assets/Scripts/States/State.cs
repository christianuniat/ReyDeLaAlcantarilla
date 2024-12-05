using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class State
{
    public virtual void Enter(){return;}
    public virtual void Exit(){return;}
    public virtual State FrameUpdate(){return null;}
    public virtual State PhisicsUpdate(){return null;}
 
}