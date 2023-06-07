using System;
using UnityEngine;

namespace StateMachine
{
    [System.Serializable]
    public class SearchState : MoveBaseState, IState
    {
        [Tooltip("NavMeshAgent.stoppingDistance")]
        [SerializeField] private float _stopping = 1f;

        private int _posIndex = 0;

        public void OnEnter(StateMachineRoot owner)
        {
            //ステート開始時の目的地を設定
            _posIndex = SetDestinationIndex();
            Agent.SetDestination(Wandering.WanderingPos[_posIndex].position);
            Agent.stoppingDistance = _stopping;

            Debug.Log("Enter Search State");
        }

        public void OnUpdate(StateMachineRoot owner)
        {
            if (Wandering.IsMove)
            {
                Search(owner);
                Movement();
            }
        }

        public void OnExit(StateMachineRoot owner)
        {
            Debug.Log("Exit Search State");
        }

        /// <summary> Playerを探す </summary>
        private void Search(StateMachineRoot owner)
        {
            var dir = Player.position - Enemy.position;
            var dist = dir.sqrMagnitude;

            //cos(θ/2)
            var cosHalf = Mathf.Cos(EnemyData.SearchAngle / 2 * Mathf.Deg2Rad);

            //内積を取得する
            var innerProduct
                = Vector3.Dot(Enemy.forward, Player.position.normalized);

            //視界に入っていて、距離が範囲内ならPlayerの追跡に切り替わる
            if (innerProduct > cosHalf && dist < SqrDistance)
            {
                Debug.Log("find player");
                owner.ChangeState(StateMachineRoot.SubState.Chase);
            }
        }

        /// <summary> 移動 </summary>
        private void Movement()
        {
            if (Anim)
            {
                //歩行Animation
            }

            var sqrMag
                = Vector3.SqrMagnitude(Enemy.position - Wandering.WanderingPos[_posIndex].position);

            if (sqrMag < _stopping * _stopping)
            {
                //目的地に到着したら次の目的地を設定
                _posIndex = SetDestinationIndex();
                Debug.Log("Change Destination");
            }
            Agent.SetDestination(Wandering.WanderingPos[_posIndex].position);
        }

        /// <summary> 次の目的地のインデックスを取得 </summary>
        private int SetDestinationIndex()
        {
            int index = Random.Range(0, Wandering.WanderingPos.Length);

            if (index == _posIndex)
            {
                //同じ場所を選んだら、選び直し
                return SetDestinationIndex();
            }

            return index;
        }
    }
}
