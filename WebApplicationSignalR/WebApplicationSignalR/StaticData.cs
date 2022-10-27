namespace WebApplicationSignalR
{
    public static class StaticData
    {
        public const string Wand = "wand";
        public const string Stone = "stone";
        public const string Cloak = "cloak";

        public static Dictionary<string, int> DeathlyHallowRace;

        static StaticData()
        {
            DeathlyHallowRace = new();
            DeathlyHallowRace.Add(Wand, 0);
            DeathlyHallowRace.Add(Stone, 0);
            DeathlyHallowRace.Add(Cloak, 0);
        }
    }
}
