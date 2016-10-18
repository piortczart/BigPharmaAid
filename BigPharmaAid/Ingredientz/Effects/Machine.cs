using System;

namespace BigPharmaAid.Ingredientz.Effects
{
    class Machine
    {
        public static readonly Machine Agglomerator = new Machine("Agglomerator", i => i + 3);
        public static readonly Machine Ioniser = new Machine("Ioniser", i => i - 3);
        public static readonly Machine Evaporator = new Machine("Evaporator", i => i + 1);
        public static readonly Machine Dissolver = new Machine("Dissolver", i => i - 1);
        public static readonly Machine CyroCondenser = new Machine("Cyro Condenser", i => Math.Min(20, i*2));
        public static readonly Machine Autoclave = new Machine("Autoclave", i => (int) Math.Floor(i/2f));

        public string Name { get; }

        private Func<int, int> LevelChange { get; }

        public Machine(string name, Func<int, int> levelChange)
        {
            Name = name;
            LevelChange = levelChange;
        }

        public int ChangeLevel(int currentLevel)
        {
            return LevelChange(currentLevel);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}