using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;

namespace Bochaterowie
{
    public abstract class Character { 
      
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public int Resistance { get; set; }

        public Character() { }

        public Character(string name, int strength, int dexterity, int intelligence, int currentHealth, int maxHealth, int damage, int resistance)
        {
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Damage = damage;  
            MaxHealth = maxHealth;
            Resistance = resistance;
            CurrentHealth = currentHealth;
        }

   
        public abstract void Equip(int additionalDamage);
        public abstract void ArmorUp(int additionalResistance);
        public abstract int GetTotalDamage();


        public void ApplyBuff(Buff buff)
        {
            // Zastosuj efekty buffa dla postaci
            Strength += buff.StrengthBonus;
            Dexterity += buff.DexterityBonus;
            Intelligence += buff.IntelligenceBonus;
            MaxHealth += buff.MaxHealthBonus;
            Damage += buff.DamageBonus;
            Resistance += buff.ResistanceBonus;
        }



    }
    public class Buff
    {
        public string Name { get; set; }
        public int StrengthBonus { get; set; }
        public int DexterityBonus { get; set; }
        public int IntelligenceBonus { get; set; }
        public int MaxHealthBonus { get; set; }
        public int DamageBonus { get; set; }
        public int ResistanceBonus { get; set; }
  
        public Buff(string name, int strengthBonus, int dexterityBonus, int intelligenceBonus, int maxHealthBonus, int damageBonus, int resistanceBonus)
        {
            Name = name;
            StrengthBonus = strengthBonus;
            DexterityBonus = dexterityBonus;
            IntelligenceBonus = intelligenceBonus;
            MaxHealthBonus = maxHealthBonus;
            DamageBonus = damageBonus;
            ResistanceBonus = resistanceBonus;
   
        }

    }

    public class Warrior : Character
    {
        private Random random = new Random();
        private static int warriorCount = 0;
        public int AttacksPerRound { get; set; }

        public Warrior(string name) : base(name, 10, 5, 3, 1, 50, 10, 10)
        {
            AttacksPerRound = 2;
            warriorCount++;
        }
        public static int GetWarriorCount()
        {
            return warriorCount;
        }


        public override void Equip(int additionalDamage)
        {
            Damage += additionalDamage;
        }

        public override void ArmorUp(int additionalResistance)
        {
            Resistance += additionalResistance;
        }

        public override int GetTotalDamage()
        {
            if (random.NextDouble() < 0.2)
            {
                return Strength * AttacksPerRound * 2;
            }
            else
            {
                return Strength * AttacksPerRound;
            }
        }


 

        
    }

    public class Archer : Character
    {
        public double DodgeChance { get; set; }
        private static int archerCount = 0;
        private Random random = new Random();
        public Archer(string name) : base(name, 3, 13, 3, 5, 30, 5, 5)
        {
            DodgeChance = 0.4; // 20% chance to dodge an attack
        }
        public static int GetArcherCount()
        {
            return archerCount;
        }



        public override void Equip(int additionalDamage)
        {
            Damage += additionalDamage;
        }

        public override void ArmorUp(int additionalResistance)
        {
            Resistance += additionalResistance;
        }

        public override int GetTotalDamage()
        {        
            if (random.NextDouble() < 0.2)
            {
                return Damage + Dexterity * 2 * 2; // Podwójne obrażenia
            }
            else
            {
                return Damage + Dexterity * 2; // Zwykłe obrażenia
            }
        }





    }

    public class Wizard : Character
    {
        private Random random = new Random();
        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }
        private static int wizardCount = 0;
        public Wizard(string name) : base(name, 1, 2, 20, 5, 25, 5, 3)
        {
            CurrentMana = 50;
            MaxMana = 50;
        }
        public static int GetWizardCount()
        {
            return wizardCount;
        }

        public override void Equip(int additionalDamage)
        {
            Damage += additionalDamage;
        }

        public override void ArmorUp(int additionalResistance)
        {
            Resistance += additionalResistance;
        }

        public override int GetTotalDamage()
        {
            if (random.NextDouble() < 0.2)
            {
                return Damage + Intelligence * 3 * 2;
            }
            else
            {
                return Damage + Intelligence * 3;
            }
        }
    }
    public class Zabojca : Character
    {
  
        private static int zabojcaCount = 0;
        private Random random = new Random();
        public Zabojca(string name) : base(name, 6, 12, 8, 20, 40, 10, 3)
        {
            
        }
        public static int GetZabojcaCount()
        {
            return zabojcaCount;
        }



        public override void Equip(int additionalDamage)
        {
            Damage += additionalDamage;
        }

        public override void ArmorUp(int additionalResistance)
        {
            Resistance += additionalResistance;
        }

        public override int GetTotalDamage()
        {
            // Sprawdzenie szansy na wykonanie backstabu (20%)
            if (random.NextDouble() < 0.4)
            {
                return Damage + Dexterity * 3 * 2; // Podwójne obrażenia
            }
            else
            {
                return Damage + Dexterity * 3; // Zwykłe obrażenia
            }
        }
    }
    public class Jednorozec : Character
    {
        private Random random = new Random();
        private static int jednorozecCount = 0;
        public Jednorozec(string name) : base(name, 3, 5, 20, 20, 80, 20, 3)
        {
          
        }
        public static int GetJednorozecCount()
        {
            return jednorozecCount;
        }



        public override void Equip(int additionalDamage)
        {
            Damage += additionalDamage;
        }

        public override void ArmorUp(int additionalResistance)
        {
            Resistance += additionalResistance;
        }

        public override int GetTotalDamage()
        {
            if (random.NextDouble() < 0.2)
            {
                return Damage + Intelligence * 5 * 2;
            }
            else
            { 
                return Damage + Intelligence * 5;
             }
        }
    }



    public class Monster 
    {
            public string Name { get; set; }
            public int Health { get; set; }
            public int Strength { get; set; }

            public Monster(string name, int health, int strength)
            {
                Name = name;
                Health = health;
                Strength = strength;
            }
    

        public void Attack(Character target)
            {
                Console.WriteLine($"{Name} attacks {target.Name}!");
                target.CurrentHealth -= Strength;
                Console.WriteLine($"{target.Name} receives {Strength} damage. {target.Name}'s Health: {target.CurrentHealth}");
            }

            public void DisplayStats()
            {
                Console.WriteLine($"Name: {Name}\nHealth: {Health}\nStrength: {Strength}");
            }

        }
        public class Quest
        {
            public string Name { get; set; }
            public List<Monster> Monsters { get; set; }
        public bool IsEasy { get; set; }

        public Quest(string name)
            {
                Name = name;
                Monsters = new List<Monster>();
            IsEasy = false;
        }

            public void AddMonster(Monster monster)
            {
                Monsters.Add(monster);
            }
        }
    }

