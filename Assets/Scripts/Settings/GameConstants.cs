namespace Settings
{
    public static class GameConstants
    {
        #region Player Info

        public const float PlayerSlideDistance = 2f;
        public static readonly float SpeedRateZX = 1.3f;

        #endregion

        #region Level states

        public static readonly float PlayerEnemyDistance = 120f;
        
        public static readonly float[] ScoreWayPoints =  {500f,1000f};
        public static readonly float[] ZSpeedChanges =  {.7f,.5f,.01f};
        public static readonly float ZSpeedCap = 35;
        public static readonly float[] EnemySpawnProbs =  {.4f,.6f,.9f};
        public static readonly float[] EnemySpawnDelays =  {1f,.7f,.5f};
        public static readonly float EnemySpawnDelayChange =  0.0001f;
        public static readonly float EnemySpawnDelayCap =  0.35f;

        #endregion
}
}
