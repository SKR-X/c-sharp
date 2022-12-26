// 3
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



//4
int[] c = {1,2,3,4,5};
int s = 1;
int[] mas = new int[c.Length * 2];
for (int i = 0; i < c.Length; i++)
{
    mas[i] = c[i]*(i + s);
}

int p = c.Length;
for (int i = 0; i < c.Length; i++)
{
    mas[p] = c[i] * c[i];
    p++;
}
int k = 0;
bool ext = false;
if (Math.Sqrt(mas.Length)!=Math.Round(Math.Sqrt(mas.Length)))
{
	k = Convert.ToInt16(Math.Round(Math.Sqrt(mas.Length))) + 1;
	ext = true;
} else
{
	k = Convert.ToInt16(Math.Sqrt(mas.Length));
}

int[,] matrix = new int[k, k];

int d = mas.Length / k;

int m = 0;
if (ext == false)
{
    for (int i = 0; i < k; i++)
    {
        for (int j = 0; j < k; j++)
        {
            matrix[i, j] = mas[m];
            m++;
        }
    }
} else
{
    for (int i = 0; i < k-1; i++)
    {
        
        if (i == k - 1)
        {
            for (int j = 0; j < k-d; j++)
            {
                matrix[i, j] = mas[m];
                m++;
            }
        } else
        {
            for (int j = 0; j < k; j++)
            {
                if (m<mas.Length)
                {
                    matrix[i, j] = mas[m];
                    m++;
                }
            }
        }
    }
}

for (int i = 0; i < matrix.GetLength(0); i++)
{
	for (int j = 0; j < matrix.GetLength(1); j++)
	{
		Console.Write($"{matrix[i,j]} ");
	}
	Console.WriteLine();
}

