using System;

//Task 2 -------------------------------------------------
class Stack64UList
{

    private List<ulong> stack = new List<ulong>();
    private List<ulong> minimum = new List<ulong>();

    public ulong push(ulong value)
    {
        stack.Add(value);

        if (stack.Count - 1 == 0) minimum.Add(value);

        else if (value < minimum[minimum.Count - 1]) minimum.Add(value);

        else minimum.Add(minimum[minimum.Count - 1]);

        return 1;
    }

    public int pop()
    {
        if (stack.Count == 0) throw new Exception("The array is empty");

        else
        {
            stack.RemoveAt(stack.Count - 1);
            minimum.RemoveAt(minimum.Count - 1);
            return 1;
        }
    }

    public int? peek()
    {
        if (stack.Count - 1 == -1) throw new Exception("The array is empty");

        else return (int)stack[stack.Count - 1];
    }

    public int isEmpty()
    {
        if (stack.Count == 0) return 1;
        else return 0;

    }

    public int stackLength()
    {
        return stack.Count;
    }

    public int? minValue()
    {
        if (stack.Count != 0) return (int)minimum[minimum.Count - 1];
        else throw new Exception("The array is empty");
    }
}

class Program
{
    static void Main()
    {
        Stack64UList stack = new Stack64UList();

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
            }
        }
    }
}

