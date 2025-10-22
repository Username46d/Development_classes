using System;
using System.Xml.Linq;
public class GameEntity
{
    public string name;
    public int health;
    public bool canTalk;
    public bool canAttack;
    public bool canMove;
    public bool canFly;

    public GameEntity(string name, int health, bool canAttack, bool canTalk, bool canMove, bool canFly)
    {
        this.name = name;
        this.health = health;
        this.canAttack = canAttack;
        this.canTalk = canTalk;
        this.canMove = canMove;
        this.canFly = canFly;
    }
    public void Move()
    {
        if (canMove)
        {
            Console.WriteLine($"{name} двигается");
        }
        else
        {
            Console.WriteLine($"{name} не может двигаться");
        }
    }
    public void Attack()
    {
        if (canAttack)
            Console.WriteLine($"{name} атакует");
        else
            Console.WriteLine($"{name} не может атаковать");
    }

    public void Talk()
    {
        if (canTalk)
            Console.WriteLine($"{name} сказал Привет");
        else
            Console.WriteLine($"{name} не может говорить");
    }

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            Console.WriteLine($"{name} получил {damage} урона. Здоровье: {health}");
        }
        else
        {
            Console.WriteLine($"{name} уничтожен");
        }
    }

    public void Fly()
    {
        if (canFly)
            Console.WriteLine($"{name} летает");
        else
            Console.WriteLine($"{name} не может летать");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{name} Здоровье: {health}, Умение говорить: {canTalk}, Атака: {canAttack}, Движение: {canMove}, Полет: {canFly}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Задача 1: Монолитный класс ===\n");

        var player = new GameEntity("Player", 100, true, true, true, false);
        var loader = new GameEntity("Loader", 0, true, false, true, false);
        var zombie = new GameEntity("Zombie", 50, false, true, true, false);

        Console.WriteLine("Игрок");
        player.DisplayInfo();
        player.Talk();
        player.Move();
        player.Attack();
        player.TakeDamage(20);

        Console.WriteLine("\nLoader");
        loader.DisplayInfo();
        loader.Talk();
        loader.Move();
        loader.Attack();

        Console.WriteLine("\nЗомби");
        zombie.DisplayInfo();
        zombie.Talk();
        zombie.Move();
        zombie.Attack();
        zombie.TakeDamage(30);

        Console.WriteLine("\nПриведение");
        var ghost = new GameEntity("Ghost", 0, canTalk: false, canAttack: true, canMove: false, canFly: true);
        ghost.DisplayInfo();
        ghost.Fly();
        ghost.Attack();
        ghost.TakeDamage(10);
    }
}
