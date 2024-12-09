public class GraphColoringBeeAlgorithm
{
    public int VerticesCount;
    public int MinDegree;
    public int MaxDegree;
    public int BeesCount;
    public int ScoutsCount;
    public int MaxIterations = 200;
    public int Interval = 20;

    private List<List<int>> graph;
    private List<Bee> bees;
    
    
    public GraphColoringBeeAlgorithm(int verticesCount = 300, int minDegree = 2, int maxDegree = 30, int beesCount = 50,
        int scoutsCount = 10)
    {
        VerticesCount = verticesCount;
        MinDegree = minDegree;
        MaxDegree = maxDegree;
        BeesCount = beesCount;
        ScoutsCount = scoutsCount;
        graph = new List<List<int>>(VerticesCount);
        bees = new List<Bee>(BeesCount);
        InitializeGraph();
        InitializeBees();
    }

    private void InitializeGraph()
    {
        Random rand = new Random();
        for (int i = 0; i < VerticesCount; i++)
        {
            graph.Add(new List<int>());
        }

        for (int i = 0; i < VerticesCount; i++)
        {
            int degree = rand.Next(MinDegree, MaxDegree + 1);
            var neighbors = new HashSet<int>();

            while (neighbors.Count < degree)
            {
                int neighbor = rand.Next(0, VerticesCount);
                if (neighbor != i)
                {
                    neighbors.Add(neighbor);
                }
            }

            foreach (var neighbor in neighbors)
            {
                if (!graph[i].Contains(neighbor))
                {
                    graph[i].Add(neighbor);
                    graph[neighbor].Add(i);
                }
            }
        }
    }

    private void InitializeBees()
    {
        for (int i = 0; i < BeesCount; i++)
        {
            if (i < ScoutsCount)
            {
                bees.Add(new BeeScout(graph));
            }
            else
            {
                bees.Add(new Bee(graph));
            }
        }
    }
    
    
    
    public void Run()
    {
        List<int> fitnessOverIterations = new List<int>();

        for (int iteration = 1; iteration <= MaxIterations; iteration++)
        {
            foreach (var bee in bees)
            {
                bee.Update();
            }

            if (iteration % Interval == 0)
            {
                int bestChromaticNumber = bees.Min(b => b.GetChromaticNumber());
                fitnessOverIterations.Add(bestChromaticNumber);
                Console.WriteLine($"Ітерацій: {iteration}, Хром. число: {bestChromaticNumber}");
            }
        }
    }
}



