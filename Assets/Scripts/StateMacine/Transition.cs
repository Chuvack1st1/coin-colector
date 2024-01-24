using System;

public class Transition
{
    private State _currentState;
    private State _nextState;
    private Func<bool> _condition;

    public State CurrentState => _currentState;
    public State NextState => _nextState;
    public Func<bool> Condition => _condition;

    public Transition(State currentState, State nextState)
    {
        _currentState = currentState;
        _nextState = nextState;
        _condition = nextState.CanEnterInState;
    }

    // ����� ��� ��������, �� ���������� �����
    public bool IsConditionMet()
    {
        return _condition.Invoke();
    }
}
