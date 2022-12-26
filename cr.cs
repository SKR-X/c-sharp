// binary
int[] mas = {1,3,4,5,7};

int left = 0;
int right = mas.Length - 1; 
int index = 0;

double q = Convert.ToDouble(Console.ReadLine()); 
int res = -1;

q = Math.Round(q,MidpointRounding.AwayFromZero);

Console.WriteLine();
while (left<=right)
{
    index = (right + left) / 2;

    if (mas[index] == q)
    {
        res = index;
        break;
    }
    if (mas[index] < q)
    {
        left = index + 1;
    }
    else
    {
        right = index - 1;
    }
}

Console.WriteLine();

Console.WriteLine();

if (res==-1)
{
    res = index;
}

for (int i = 0; i < mas.Length; i++)
{
    if (i!=res)
    {
        Console.WriteLine(mas[i]);
    }
}
