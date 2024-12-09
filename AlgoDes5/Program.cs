
static class Program
{
    static void Main(string[] args)
    {
        Console.Write("Які параметри дамо:\n1 - к-ть бджіл\n2 - ділянки\n3 - обидва:");
        int choice = int.Parse(Console.ReadLine());
        GraphColoringBeeAlgorithm algorithm;
        switch (choice)
        {
            case 1:
                Console.Write("Кількість бджіл: ");
                int bees = int.Parse(Console.ReadLine());
                Console.Write("К-ть бджіл-розвідників: ");
                int scoutBees = int.Parse(Console.ReadLine());
                algorithm = new GraphColoringBeeAlgorithm(beesCount: bees, scoutsCount: scoutBees);
                break;

            case 2:
                Console.Write("Кількість вершин: ");
                int verticesCount = int.Parse(Console.ReadLine());
                Console.Write("Мінімальний степінь вершини: ");
                int minDegree = int.Parse(Console.ReadLine());
                Console.Write("Максимальний степінь вершини: ");
                int maxDegree = int.Parse(Console.ReadLine());
                algorithm = new GraphColoringBeeAlgorithm(verticesCount: verticesCount, minDegree: minDegree,
                    maxDegree: maxDegree);
                break;

            case 3:
                Console.Write("Кількість бджіл: ");
                bees = int.Parse(Console.ReadLine());
                Console.Write("К-ть бджіл-розвідників: ");
                scoutBees = int.Parse(Console.ReadLine());
                Console.Write("Кількість вершин: ");
                verticesCount = int.Parse(Console.ReadLine());
                Console.Write("Мінімальний степінь вершини: ");
                minDegree = int.Parse(Console.ReadLine());
                Console.Write("Максимальний степінь вершини: ");
                maxDegree = int.Parse(Console.ReadLine());
                algorithm = new GraphColoringBeeAlgorithm(verticesCount, minDegree, maxDegree, bees, scoutBees);
                break;

            default:
                algorithm = new GraphColoringBeeAlgorithm();
                break;
        }

        algorithm.Run();

        Console.WriteLine("Алгоритм завершено");
    }
}



//
// class GraphColoringBeeAlgorithm
// {
//     static Random random = new Random();
//     static int VertexCount = 300;
//     static int[,] Graph = new int[VertexCount, VertexCount]; // Матриця суміжності
//
//     static int BeesCount = 50;
//     static int ScoutsCount = 10;
//     static int SitesCount = 20;
//     static int MaxIterations = 100;
//
//     static void Main(string[] args)
//     {
//         GenerateGraph();
//         int[] beeCounts = { 30, 50, 100 };
//         int[] siteCounts = { 5, 10, 15 };
//         int[] iterations = { 100, 500, 1000 };
//
//         foreach (var bees in beeCounts)
//         {
//             foreach (var sites in siteCounts)
//             {
//                 foreach (var iter in iterations)
//                 {
//                     BeesCount = bees;
//                     SitesCount = sites;
//                     MaxIterations = iter;
//
//                     int bestChromaticNumber = RunBeeAlgorithm();
//                     Console.WriteLine(
//                         $"Бджоли: {bees}, Ділянки: {sites}, Ітерації: {iter} -> Хроматичне число: {bestChromaticNumber}");
//                 }
//             }
//         }
//     }
//
//     static void GenerateGraph()
//     {
//         for (int i = 0; i < VertexCount; i++)
//         {
//             int degree = random.Next(2, 31); // Ступінь вершини
//             for (int j = 0; j < degree; j++)
//             {
//                 int neighbor = random.Next(0, VertexCount);
//                 Graph[i, neighbor] = Graph[neighbor, i] = 1;
//             }
//         }
//     }
//
//     static int RunBeeAlgorithm()
//     {
//         List<int[]> solutions = InitializeSolutions();
//         int bestSolution = int.MaxValue;
//
//         for (int iter = 0; iter < MaxIterations; iter++)
//         {
//             solutions = EvaluateAndOptimize(solutions);
//             int currentBest = solutions.Min(GetChromaticNumber);
//             if (currentBest < bestSolution)
//             {
//                 bestSolution = currentBest;
//             }
//
//             if (bestSolution == 0) break; // Ідеальне рішення
//         }
//
//         return bestSolution;
//     }
//
//     static List<int[]> InitializeSolutions()
//     {
//         var solutions = new List<int[]>();
//         for (int i = 0; i < BeesCount; i++)
//         {
//             solutions.Add(GenerateRandomSolution());
//         }
//
//         return solutions;
//     }
//
//     static int[] GenerateRandomSolution()
//     {
//         int[] colors = new int[VertexCount];
//         for (int i = 0; i < VertexCount; i++)
//         {
//             colors[i] = random.Next(1, VertexCount + 1); // Випадковий колір
//         }
//
//         return colors;
//     }
//
//     static List<int[]> EvaluateAndOptimize(List<int[]> solutions)
//     {
//         var newSolutions = new List<int[]>();
//
//         // Фуражири оптимізують
//         for (int i = 0; i < BeesCount - ScoutsCount; i++)
//         {
//             var solution = solutions[i];
//             newSolutions.Add(LocalOptimization(solution));
//         }
//
//         // Розвідники додають нові рішення
//         for (int i = 0; i < ScoutsCount; i++)
//         {
//             newSolutions.Add(GenerateRandomSolution());
//         }
//
//         return newSolutions;
//     }
//
//     static int[] LocalOptimization(int[] solution)
//     {
//         int[] newSolution = (int[])solution.Clone();
//         int vertex = random.Next(VertexCount);
//         newSolution[vertex] = random.Next(1, VertexCount + 1); // Новий колір
//         return newSolution;
//     }
//
//     static int GetChromaticNumber(int[] solution)
//     {
//         int conflicts = 0;
//         for (int i = 0; i < VertexCount; i++)
//         {
//             for (int j = 0; j < VertexCount; j++)
//             {
//                 if (Graph[i, j] == 1 && solution[i] == solution[j])
//                     conflicts++;
//             }
//         }
//
//         return conflicts;
//     }
// }
