using UnityEngine;

namespace StateMachine
{
    public class MoveBaseState : State
    {
        private MoveChildState _moveChild = MoveChildState.Search;

        private SearchState _searchState = default;
        private ChaseState _chaseState = default;
        private RunAwayState _runAwayState = default;

        public MoveChildState MoveChild => _moveChild;

        public override void OnEnter(StateMachineRoot owner)
        {
            Debug.Log("Enter Move State");
        }

        public override void OnUpdate(StateMachineRoot owner)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Move State");
        }

        public enum MoveChildState
        {
            Search,
            Chase,
            RunAway
        }
    }
}
