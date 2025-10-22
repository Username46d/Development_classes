using System;

public abstract class GameEntity
{
    public abstract void DisplayInfo();
}

public abstract class Character : GameEntity
{
    public int Health;
    public bool CanMove;

    protected Character(int health, bool canMove)
    {
        Health = health;
        CanMove = canMove;
    }

    public virtual void Move()
    {
        if (CanMove)
            Console.WriteLine($"{GetType().Name} идет");
        else
            Console.WriteLine($"{GetType().Name} не может ходить");
    }

    public virtual void TakeDamage(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;
            Console.WriteLine($"{GetType().Name} получил {damage} урона. Здоровье: {Health}");
        }
    }
}

public abstract class TalkableCharacter : Character
{
    public string Name { get; protected set; }
    public bool CanTalk { get; protected set; }

    protected TalkableCharacter(string name, int health, bool canMove, bool canTalk)
        : base(health, canMove)
    {
        Name = name;
        CanTalk = canTalk;
    }

    public virtual void Talk()
    {
        if (CanTalk)
            Console.WriteLine($"{Name} сказал Привет");
        else
            Console.WriteLine($"{GetType().Name} не может говорить");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Имя: {Name}, Здоровье: {Health}, Умение говорить: {CanTalk}");
    }
}

public abstract class AttackingCharacter : Character
{
    public bool CanAttack { get; protected set; }
    public int AttackDamage { get; protected set; }

    protected AttackingCharacter(int health, bool canMove, bool canAttack, int attackDamage = 10)
        : base(health, canMove)
    {
        CanAttack = canAttack;
        AttackDamage = attackDamage;
    }

    public virtual void Attack()
    {
        if (CanAttack)
            Console.WriteLine($"{GetType().Name} нанес {AttackDamage} урона!");
        else
            Console.WriteLine($"{GetType().Name} не может атаковать");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Здоровье: {Health}, Атака: {CanAttack}, Урон: {AttackDamage}");
    }
}

public class Player : TalkableCharacter
{
    public bool CanAttack { get; private set; }
    public int AttackDamage { get; private set; }

    public Player(string name, int health)
        : base(name, health, canMove: true, canTalk: true)
    {
        CanAttack = true;
        AttackDamage = 15;
    }

    public void Attack()
    {
        if (CanAttack)
            Console.WriteLine($"{Name} нанес {AttackDamage} урона!");
        else
            Console.WriteLine($"{Name} не может атаковать");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Игрок: {Name}, Здоровье: {Health}, Атака: {CanAttack}");
    }
}

public class Loader : TalkableCharacter
{
    public Loader(string name)
        : base(name, health: 0, canMove: true, canTalk: true)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Loader: {Name}, Движение: {CanMove}, Разговорчивость: {CanTalk}");
    }
}

public class Zombie : AttackingCharacter
{
    public Zombie(int health)
        : base(health, canMove: true, canAttack: true, attackDamage: 8)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"ЗомбиЗдоровье: {Health}, Атака: {CanAttack}");
    }
}

public class Box : GameEntity
{
    public int Health { get; private set; }

    public Box(int health)
    {
        Health = health;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"Коробка получила {damage} урона. Здоровье: {Health}");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Коробка Здоровье: {Health}");
    }
}

class Program
{
    static void Main(string[] args)
    {

        var player = new Player("John", 100);
        var loader = new Loader("Bob");
        var zombie = new Zombie(50);
        var box = new Box(20);

        Console.WriteLine("Player");
        player.DisplayInfo();
        player.Move();
        player.Talk();
        player.Attack();

        Console.WriteLine("\nLoader");
        loader.DisplayInfo();
        loader.Move();
        loader.Talk();

        Console.WriteLine("\nZombie");
        zombie.DisplayInfo();
        zombie.Move();
        zombie.Attack();

        Console.WriteLine("\nBox");
        box.DisplayInfo();
        box.TakeDamage(5);

    }
}