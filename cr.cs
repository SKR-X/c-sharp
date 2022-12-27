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

//5
int[,] matrix = { { 1, 2, 3, 4,5,6 },
                  { 1, 2, 3, 4,5,6 },
                  { 1, 2, 3, 4,5,6 },
                  { 1, 1, 3, 4,5,6 }};
int previ = 0;
int prevj = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (i%2==0 && j%2==0)
        {
            matrix[i, j] = matrix[i, j] - matrix[i, j]*2;
        } else if(i%2!=0 && j%2!=0 && (i < matrix.GetLength(1) && j < matrix.GetLength(0)) && matrix[j,i] % 2!=0 && i!=prevj && j!=previ)
        {
            int temp = matrix[i, j];
            matrix[i, j] = matrix[j, i];
            matrix[j, i] = temp;
            previ = i;
            prevj = j;
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


//6
using System;

namespace ConsoleApp10
{
    class Program
    {

        static int maxPlace(int[,] matrix, int maxi, int maxj)
        {
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0) / 2; i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    c++;
                    if (i == maxi && j == maxj)
                    {
                        return c;
                    }
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            int[,] matrix = { {5,3,10,2,1},
                  {1,2,3,4,5},
                  {1,2,3,4,5},
                  {1,2,3,4,5} };
            int max = 0, maxi = 0, maxj = 0;
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0) / 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxi = i;
                        maxj = j;
                    }
                }
            }

            int maxPlaceC = maxPlace(matrix,maxi,maxj);

            int[] firstMas = new int[(matrix.GetLength(0)/2)*matrix.GetLength(1)];
            c = 0;
            for (int i = 0; i < matrix.GetLength(0) / 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    firstMas[c] = matrix[i,j];
                    c++;
                }
            }

            var step = firstMas.Length / 2;

            while (step > 0)
            {
                for (int i = step; i < firstMas.Length; i++)
                {
                    int j = i;
                    while ((j >= step) && firstMas[j - step] > firstMas[j])
                    {
                        var temp = firstMas[j - step];
                        firstMas[j - step] = firstMas[j];
                        firstMas[j] = temp;
                        j -= step;
                    }
                }
                step /= 2;
            }
            c = 0;
            int[] inpMas = new int[firstMas.Length];
            for (int i = 0; i < maxPlaceC; i++)
            {
                inpMas[i] = firstMas[c];
                c++;
            }
            for (int i = maxPlaceC+1; i < inpMas.Length; i++)
            {
                inpMas[i] = firstMas[c];
                c++;
            }
            inpMas[maxPlaceC] = max;
            c = 0;
            for (int i = 0; i < matrix.GetLength(0)/2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = inpMas[c];
                    c++;
                }
            }

            for (int i = 0; i < matrix.GetLength(0) / 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();


        }
    }
}
