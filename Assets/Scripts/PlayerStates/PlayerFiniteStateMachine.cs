public class PlayerFiniteState
{
    Player _parent;
    State initialState;
    public State CurrentState;

    public PlayerFiniteState(Player _player, State _initialState)
    {
        _parent = _player;
        initialState = _initialState;
        CurrentState = initialState;
        CurrentState.Enter();
    }
    public void FrameUpdate()
    {
        State _newState = CurrentState.FrameUpdate();
        if (_newState == null) return;
        ChangeState(_newState);
    }
    public void PhisicsUpdate()
    {
        State _newState = CurrentState.PhisicsUpdate();
        if (_newState == null) return;
        ChangeState(_newState);
    }
    void ChangeState(State state)
    {
        state.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
}

