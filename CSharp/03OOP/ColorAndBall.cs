namespace _03OOP;

public static class ColorAndBall
{
    public static void Main(string[] args)
    {
        Color color1 = new Color(255, 0, 0);
        Color color2 = new Color(0, 100, 100, 100);

        Ball ball1 = new Ball(color1, 5);
        Ball ball2 = new Ball(color2);

        ball1.Throw();
        ball2.Throw();
        Console.WriteLine($"Ball1 thrown: {ball1.TimesThrown}");
        Console.WriteLine($"Ball2 thrown: {ball2.TimesThrown}");

        ball1.Pop();
        Console.WriteLine("Ball1 popped");

        ball1.Throw();
        ball2.Throw();
        Console.WriteLine($"Ball1 thrown: {ball1.TimesThrown}");
        Console.WriteLine($"Ball2 thrown: {ball2.TimesThrown}");
    }
}

public class Color
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    public int Alpha { get; set; }

    public Color(int red, int green, int blue, int alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    public Color(int red, int green, int blue) : this(red, green, blue, 255)
    {
    }

    public int GetGrayscale()
    {
        return (Red + Green + Blue) / 3;
    }
}

public class Ball
{
    public int Size { get; set; }
    public Color Color { get; set; }
    public int TimesThrown { get; set; }

    public Ball(Color color, int size)
    {
        Size = size;
        Color = color;
        TimesThrown = 0;
    }

    public Ball(Color color) : this(color, 1)
    {
    }


    public void Pop()
    {
        Size = 0;
    }

    public void Throw()
    {
        if (Size > 0)
        {
            TimesThrown++;
        }
    }
}