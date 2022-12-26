// binary
int[] mas = {1,2,3,4,5,6,7};

int left = 0;
int right = mas.Length - 1; 
int index = 0;

double q = Convert.ToDouble(Console.ReadLine()); 
int res = -1;

q = Math.Round(q,MidpointRounding.AwayFromZero);

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

for (int i = 0; i < mas.Length; i++)
{
    if (i!=res)
    {
        Console.WriteLine(mas[i]);
    }
}
