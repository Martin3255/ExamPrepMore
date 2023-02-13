using System.Numerics;
using System.Security.Cryptography.X509Certificates;

int size = int.Parse(Console.ReadLine());
string[,] battleField = new string[size, size];

int submRow = -1;
int submCol = -1;

int cruisersHit = 0;
int minesHit = 0;

for (int row = 0; row < size; row++)
{
    string rowData = Console.ReadLine();
    for (int col = 0; col < size; col++)
    {
        battleField[row, col] = rowData[col].ToString();
        if (rowData[col] == 'S')
        {
            battleField[row, col] = "-";
            submRow = row;
            submCol = col;
        }
    }
}
while (true)
{
    if (minesHit == 3)
    {
        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submRow}, {submCol}]!");
        break;
    }
    if (cruisersHit == 3)
    {
        Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
        break;
    }
    string command = Console.ReadLine().ToLower();

    if (command == "left")
    {
        submCol--;
    }
    if (command == "right")
    {
        submCol++;
    }
    if (command == "up")
    {
        submRow--;
    }
    if (command == "down")
    {
        submRow++;
    }
    if (battleField[submRow, submCol] == "C")
    {
        battleField[submRow, submCol] = "-";
        cruisersHit++;
    }
    if (battleField[submRow, submCol] == "*")
    {
        battleField[submRow, submCol] = "-";
        minesHit++;
    }
}
battleField[submRow, submCol] = "S";
for (int i = 0; i < size; i++)
{
    for (int j = 0; j < size; j++)
    {
        Console.Write(battleField[i, j]);
    }
    Console.WriteLine();
}
void Print()
{
;
}