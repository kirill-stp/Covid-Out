namespace Settings
{
    public static class GameConstants
    {
        #region Player Info

        public const float PlayerSlideDistance = 2f;
        public static readonly float SpeedRateZX = 1.5f;

        #endregion

        #region Level states

        public static readonly float PlayerEnemyDistance = 100f;
        
        public static readonly float[] ScoreWayPoints =  {100f,300f};
        public static readonly float[] ZSpeedChanges =  {1f,.5f,.01f};
        public static readonly float[] EnemySpawnProbs =  {.3f,.5f,.7f};
        public static readonly float[] EnemySpawnDelays =  {1f,.7f,.4f};

    #endregion
}
}
