BinOperation operation = sum;
operation += mult;

operation -= sum;

Console.WriteLine(operation?.Invoke(10, 20));

BinOperation op2 = new User().AddSalary;

BinOperation opRes = operation + op2;

BinOperation op3 = null;

Square<double, int> square = CircleSquare;
Square<int, float> square1 = RectangleSquare;


if(op3 is not null)
    op3(10, 20);
op3?.Invoke(10, 20);

User user = null;
user?.AddSalary(100, 200);

Console.WriteLine(Calc(10, 20, operation));


Player player = new Player() { Name = "Bob", Level = 10 };


player.Info = InfoGreenConsole;

player.InfoPrint();

void InfoConsole(string message)
{
    Console.WriteLine(message);
}

void InfoGreenConsole(string message)
{
    ConsoleColor color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(message);
    Console.ForegroundColor = color;
}

BinOperation OperationCreate(OpType type)
{
    switch(type)
    {
        case OpType.Add: return sum;
        case OpType.Mult: return mult;
        default:
            return null;
    }
}

int Calc(int a, int b, BinOperation operation)
{
    return operation(a, b);
}

int sum(int a, int b)
{
    Console.WriteLine("Method Sum");
    return a + b;
}

int mult(int a, int b)
{
    Console.WriteLine("Method Mult");
    return a * b;
}

double CircleSquare(int r)
{
    return 2 * Math.PI * r;
}

int RectangleSquare(float w)
{
    return (int)(w * w);
}

class User
{
    public int Salary { get; set; }
    public int AddSalary(int salary, int addSum)
    {
        Salary = salary + addSum;
        return Salary;
    }
}

enum OpType
{
    Add,
    Mult,
    Div,
    Sub
}

delegate int BinOperation(int a, int b);

delegate T Square<T, U>(U a);

class Player
{
    public string Name { get; set; }
    public int Level { get; set; }

    public InfoMessage Info { get; set; }

    public void InfoPrint()
    {
        Info?.Invoke($"Player name: {Name} level: {Level}");
    }
    //public void Info()
    //{
    //    Console.WriteLine($"Player: {Name}, Level: {Level}");
    //}
}

delegate void InfoMessage(string message);