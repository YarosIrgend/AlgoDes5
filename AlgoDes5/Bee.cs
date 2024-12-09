using System;
using System.Collections.Generic;
using System.Linq;

public class Bee
{
    protected List<List<int>> graph;
    protected int[] colors;

    public Bee(List<List<int>> graph)
    {
        this.graph = graph;
        this.colors = new int[graph.Count];
        InitializeRandomColors();
    }

    private void InitializeRandomColors()
    {
        Random rand = new Random();
        for (int i = 0; i < graph.Count; i++)
        {
            colors[i] = rand.Next(1, graph.Count + 1);
        }
    }

    public virtual void Update()
    {
        Random rand = new Random();
        int vertexToChange = rand.Next(0, graph.Count);
        HashSet<int> neighborColors = new HashSet<int>();

        foreach (var neighbor in graph[vertexToChange])
        {
            neighborColors.Add(colors[neighbor]);
        }

        int newColor = 1;
        while (neighborColors.Contains(newColor))
        {
            newColor++;
        }

        colors[vertexToChange] = newColor;
    }

    public int GetChromaticNumber()
    {
        return colors.Distinct().Count();
    }
}

public class BeeScout : Bee
{
    public BeeScout(List<List<int>> graph) : base(graph)
    {
    }

    public override void Update()
    {
        Random rand = new Random();
        int verticesToChange = rand.Next(1, graph.Count / 10);

        for (int i = 0; i < verticesToChange; i++)
        {
            int vertexToChange = rand.Next(0, graph.Count);
            HashSet<int> neighborColors = new HashSet<int>();

            foreach (var neighbor in graph[vertexToChange])
            {
                neighborColors.Add(colors[neighbor]);
            }

            int newColor = 1;
            while (neighborColors.Contains(newColor))
            {
                newColor++;
            }

            colors[vertexToChange] = newColor;
        }
    }
}
