using UnityEngine;

namespace Morganheim.ScriptableEvents
{
    public readonly struct StringId : IEquatable<StringId>
    {
        public readonly int Hash;
        public readonly string Name;

        public StringId(string name)
        {
            Name = name;
            Hash = StableHash(name);
        }

        public bool Equals(StringId other) => Hash == other.Hash && Name == other.Name;

        public override bool Equals(object obj) => obj is StringId other && Equals(other);

        public override int GetHashCode() => Hash;

        public override string ToString() => Name;

        public static implicit operator StringId(string name) => new StringId(name);

        private static int StableHash(string text)
        {
            unchecked
            {
                int hash = 23;
                for (int i = 0; i < text.Length; i++)
                    hash = hash * 31 + text[i];

                return hash;
            }
        }
    }
}