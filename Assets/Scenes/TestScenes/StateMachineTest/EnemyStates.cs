﻿namespace StateMachine
{
    public class EnemyStates
    {
        private BaseState _baseState = BaseState.Idle;

        public BaseState Base => _baseState;

        public enum BaseState
        {
            Idle,
            Move,
            Conduct
        }
    }
}
