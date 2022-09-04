namespace CrashBandicoot
{
    public static class Global
    {
        public struct ExecutionOrder
        {
            public const int MANAGERS = -1;
        }

        public struct SettingsPath
        {
            public const string BASE = "Crash Bandicoot/";
            public const string LEVEL = BASE + "Levels/";
            public const string PLAYERS = BASE + "Players/";
        }

        public struct SettingsOrder
        {
            public const int BASE = 100;
            public const int PLAYERS = BASE + 1;
        }
    }
}