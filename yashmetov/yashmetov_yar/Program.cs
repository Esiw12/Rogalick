
using System;
using System.Collections.Generic;
using yashmetov;
class Program
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать, воин!");
        Console.Write("Назови себя: ");
        string playerName = Console.ReadLine();

      
        Player player = new Player(playerName, 100);
       
        player.HealthKit = new Aid("Средняя аптечка", 10);

        int totalPoints = 0;

        //список
        List<Enemy> enemies = new List<Enemy>
        {
            new Enemy("Варвар", new Random().Next(20, 100), new Weapon("Экскалибур", 10, 100)),
            new Enemy("Бродяга", new Random().Next(20, 100), new Weapon("Драконоборец", 15, 100)),
            new Enemy("Темный рыцарь", new Random().Next(20, 100), new Weapon("Адский клинок", 18, 100)),
            new Enemy("Маг-повелитель", new Random().Next(20, 100), new Weapon("Волшебная палочка", 12, 100)),
            new Enemy("Огненный дракон", new Random().Next(20, 100), new Weapon("Огненное дыхание", 25, 100))
        };

        List<Weapon> playerWeapons = new List<Weapon>
{
    new Weapon("заточка", 15, 100),
    new Weapon("Молот-тора", 25, 100),
    new Weapon("Лук-эльфа", 16, 100),
    new Weapon("Повелитель земли", 20, 100),
    new Weapon("Щит капитана америки", 18, 100)
};
        List<Weapon> weapons = new List<Weapon>
{
   new Weapon("Экскалибур", 10, 100),
    new Weapon("Драконоборец", 15, 100),
    new Weapon("Адский клинок", 18, 100),
    new Weapon("Волшебная палочка", 12, 100),
    new Weapon("Огненное дыхание", 25, 100)
};
        while (player.CurrentHealth > 0)
        {
            Enemy enemy = enemies[new Random().Next(enemies.Count)];
            Weapon enemyWeapon = weapons[new Random().Next(weapons.Count)];
            player.CurrentWeapon = playerWeapons[new Random().Next(playerWeapons.Count)];
            enemy.EnemyWeapon = enemyWeapon;
            Console.WriteLine($"Вы встречаете врага {enemy.Name} ({enemy.CurrentHealth}hp), у врага на поясе сияет оружие {enemy.EnemyWeapon.Name} ({enemy.EnemyWeapon.Damage}).");
            while (player.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                Console.WriteLine($"Здоровье игрока: {player.CurrentHealth}, Здоровье противника: {enemy.CurrentHealth}");
                Console.WriteLine($"Ваше имя: {player.Name}, у вас оружие: {player.CurrentWeapon.Name}");

                Console.WriteLine("Что вы будете делать?");
                Console.WriteLine("1. Ударить");
                Console.WriteLine("2. Пропустить ход");
                Console.WriteLine("3. Использовать аптечку");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        player.Attack(enemy);
                        Console.WriteLine($"Вы ударили {enemy.Name}!");
                        break;
                    case "2":
                        Console.WriteLine("Вы пропускаете ход.");
                        break;
                    case "3":
                        player.Heal();
                        Console.WriteLine($"Вы использовали аптечку. Ваше текущее здоровье: {player.CurrentHealth}");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите 1, 2 или 3.");
                        break;
                }

     
                enemy.Attack(player);
                Console.WriteLine($"{enemy.Name} атакует вас! Ваше текущее здоровье: {player.CurrentHealth}");
            }

            if (player.CurrentHealth <= 0)
            {
                Console.WriteLine($"Игра окончена. {enemy.Name} победил! Ваши общие очки {totalPoints}");
                break;
            }
            else
            {
                Console.WriteLine($"Вы победили {enemy.Name} и получили очки!");


                player.CurrentHealth += 20;
                Console.WriteLine($"Вы исцелились на 20 хп. Ваше здоровье: {player.CurrentHealth}");
                totalPoints += 10; 
                Console.WriteLine($"Ваши текущие очки: {totalPoints}");

                Console.WriteLine("Хотите продолжить игру? (Да/Нет)");
                string continueChoice = Console.ReadLine();
                if (continueChoice.ToLower() != "да")
                {
                    Console.WriteLine($"Игра завершена. Ваши общие очки: {totalPoints}");
                    break;
                }
            }
        }
    }
}
