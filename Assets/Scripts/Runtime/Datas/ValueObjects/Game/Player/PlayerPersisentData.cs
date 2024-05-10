namespace HiveMindGameTemplate.Runtime.Datas.ValueObjects.Game.Player
{
    public struct PlayerPersisentData
    {
        #region Fields
        public int MaxHealth;
        public int Level;
        public int CurrentXP;
        public int ProgressPercent;
        public int SkillPoint;
        #endregion

        #region Constructor
        public PlayerPersisentData(int maxHealth, int level, int currentXP, int progressPercent, int skillPoint)
        {
            MaxHealth = maxHealth;
            Level = level;
            CurrentXP = currentXP;
            ProgressPercent = progressPercent;
            SkillPoint = skillPoint;
        }
        #endregion
    }
}
