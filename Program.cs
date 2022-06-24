using System;

public class Test
{
    public static void Main(string[] args)
    {
        string input = Console.In.ReadLine();
        int cases = Convert.ToInt32(input);
        int[][,] outputs = new int[cases][,];


        for (int i = 0; i < cases; i++)
        {
            input = Console.In.ReadLine();
            string[] tokens = input.Split();

            int n = Convert.ToInt32(tokens[0]);
            int m = Convert.ToInt32(tokens[1]);
            int[,] arrayInput = new int[n, m];

            for (int j = 0; j < n; j++)
            {
                input = Console.In.ReadLine();
                char[] bits = input.ToCharArray();

                for (int k = 0; k < bits.Length; k++)
                {
                    if (Convert.ToInt32(input[k]) == 48)
                    {
                        arrayInput[j, k] = 0;
                    }
                    else
                        arrayInput[j, k] = 1;

                }

            }

            Case actual = new Case(n, m, arrayInput);
            int[,] output = Case.Output(actual);
            outputs[i] = output;



        }
        Console.In.Close();
        for (int i = 0; i < outputs.Length; i++)
        {
            int[,] print = outputs[i];
            for (int j = 0; j < print.GetLength(0); j++)
            {
                for (int k = 0; k < print.GetLength(1); k++)
                {
                    Console.Out.Write(print[j, k]);
                    Console.Out.Write(" ");
                }
                Console.Out.WriteLine();
            }
            Console.Out.Close();
        }


    }
}


public class Case
{
    public int rows { get; set; }
    public int columns { get; set; }
    public int[,] bitMap { get; set; }

    public Case(int rows, int columns, int[,] bitMap)
    {
        this.rows = rows;
        this.columns = columns;
        this.bitMap = bitMap;
    }
    static int calculate(int i1, int i2, int j1, int j2)
    {
        int distance = 0;
        int valueI = i1 - i2;
        int valueJ = j1 - j2;
        if (valueI < 0)
            valueI = valueI * (-1);
        if (valueJ < 0)
            valueJ = valueJ * (-1);
        distance = valueI + valueJ;
        return distance;
    }

    public static int[,] Output(Case actual)
    {
        int[,] output = new int[actual.rows, actual.columns];

        for (int i = 0; i < actual.rows; i++)
        {

            for (int j = 0; j < actual.columns; j++)
            {


                if (actual.bitMap[i, j] == 1)
                    output[i, j] = 0;
                else
                {
                    output[i, j] = calculateClose(i, j, actual);
                }
            }
        }

        return output;
    }

    static int calculateClose(int x, int y, Case actual)
    {
        int close = 999;

        for (int i = 0; i < actual.rows; i++)
        {

            for (int j = 0; j < actual.columns; j++)
            {

                if (actual.bitMap[i, j] == 1)
                {
                    int near = calculate(x, i, y, j);
                    if (near < close)
                    {
                        close = near;
                    }
                }
            }
        }


        return close;
    }


}