using System;

class Stack64U
{
    private ulong[] stack = new ulong[5];
    private ulong[] minimum = new ulong[5];
    private long top = -1;

    private void resize()
    {
        ulong[] newStack;
        ulong[] newMinimum;

        if (top == stack.Length - 1)
        {
            newStack = new ulong[stack.Length * 2];
            newMinimum = new ulong[minimum.Length * 2];
            for (int i = 0; i <= top; i++)
            {
                newStack[i] = stack[i];
                newMinimum[i] = minimum[i];
            }
        }
        else
        {
            newStack = new ulong[stack.Length / 2];
            newMinimum = new ulong[minimum.Length / 2];
            for (int i = 0; i <= top / 2; i++)
            {
                newStack[i] = stack[i];
                newMinimum[i] = minimum[i];
            }
        }

        stack = newStack;
        minimum = newMinimum;
    }

    public ulong push(ulong value)
    {
        if (top + 1 == stack.Length) resize();

        top++;

        stack[top] = value;

        if (top == 0) minimum[top] = value;

        else if (value < minimum[top - 1]) minimum[top] = value;

        else minimum[top] = minimum[top - 1];

        return 1;
    }

    public int pop()
    {
        if (top == stack.Length / 2) resize();

        if (top == -1) throw new Exception("The array is empty");

        else
        {
            top--;
            return 1;
        }
    }

    public int? peek()
    {
        if (top == -1) throw new Exception("The array is empty");

        else return (int)stack[top];
    }

    public int isEmpty()
    {
        if (top == -1) return 1;
        else return 0;

    }

    public int stackLength()
    {
        return (int)top + 1;
    }

    public int? minValue()
    {
        if (top != -1) return (int)minimum[top];
        else throw new Exception("The array is empty");
    }

    //För att se hur stor kapasitet stacken har:)
    public int stackCapacity()
    {
        return stack.Length;
    }
}
class Program
{
    static void Main()
    {
        Stack64U stack = new Stack64U();

        ulong data;

        while (true)
        {
            Console.WriteLine("1. Push\n2. Pop\n3. Peek\n4. Is empty\n5. Stack length\n6. Minimun value");
            data = Convert.ToUInt64(Console.ReadLine());

            switch (data)
            {
                case 1:
                    Console.WriteLine("Enter value to push:");
                    data = Convert.ToUInt64(Console.ReadLine());

                    stack.push(data);
                    Console.WriteLine("Value pushed");

                    break;

                case 2:
                    stack.pop();
                    Console.WriteLine("Pop sucess");

                    break;

                case 3:
                    Console.WriteLine("Top value is: " + stack.peek());

                    break;

                case 4:
                    if (stack.isEmpty() == 1) Console.WriteLine("Stack is empty");

                    else Console.WriteLine("Stack is not empty");

                    break;

                case 5:
                    Console.WriteLine("Stack length is: " + stack.stackLength());

                    break;

                case 6:
                    Console.WriteLine("Minimum value is: " + stack.minValue());

                    break;

                    //Task1
                    case 7:
                        Console.WriteLine("Stack capacity is: " + stack.stackCapacity());
                        break;
            }
        }
    }
}
