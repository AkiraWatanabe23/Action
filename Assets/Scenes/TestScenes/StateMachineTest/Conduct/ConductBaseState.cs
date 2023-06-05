using UnityEngine;

namespace StateMachine
{
    [System.Serializable]
    /// <summary> 行動関連のステートの基底クラス </summary>
    public class ConductBaseState
    {
        [SerializeField] private int _attackValue = 1;

        public int AttackValue => _attackValue;

        public void Init()
        {

        }
    }
}
