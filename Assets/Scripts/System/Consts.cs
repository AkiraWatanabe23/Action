using System.Collections.Generic;

namespace Constants
{
    public static class Consts
    {
        public const int CLEAR_KILL_COUNT = 10;

        public static readonly Dictionary<SceneNames, string> Scenes = new()
        {
            [SceneNames.TITLE_SCENE] = "Title",
            [SceneNames.GAME_SCENE] = "InGame",
            [SceneNames.RESULT_SCENE] = "Result",
        };

        public const string ANIM_IDLE = "Idle";
        public const string ANIM_MOVE = "Move";
        public const string ANIM_JUMP = "Jump";
        public const string ANIM_MIDAIR = "MidAir";
        public const string ANIM_LAND = "Land";
        public const string ANIM_ATTACK = "Attack";
        public const string ANIM_DAMAGE = "Damage";
        public const string ANIM_DEAD = "Death";
    }

    public enum SceneNames
    {
        TITLE_SCENE,
        GAME_SCENE,
        RESULT_SCENE,
    }
}
