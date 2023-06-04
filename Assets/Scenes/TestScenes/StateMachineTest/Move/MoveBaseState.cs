using UnityEngine;

namespace StateMachine
{
    /// <summary> 動き関連のステートの基底クラス </summary>
    public class MoveBaseState
    {
        private Transform _player = default;

        public void Init(Transform player)
        {
            _player = player;
        }
    }
}
