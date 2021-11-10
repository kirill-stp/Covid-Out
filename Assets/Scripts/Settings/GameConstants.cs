namespace Settings
{
    public static class GameConstants
    {
        #region Player Info

        public const float PlayerSlideDistance = 2f;
        public const float PlayerEnemyDistance = 100f;

        #endregion

        #region Difficulty

        public static readonly float[] ScoreWayPoints =  {100f,300f};
        public static readonly float[] ZSpeedChanges =  {1f,.5f,.01f};
        public static readonly float[] XSpeedChanges =  {.1f,.05f,.001f};
        public static readonly float[] EnemySpawnProbs =  {.3f,.5f,.7f};
        public static readonly float[] EnemySpawnDelays =  {1f,.7f,.4f};

    #endregion
}
}
