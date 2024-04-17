class GrafoEstacao()
{
    Dictionary<string, List<Tuple<string, int>>> estacoes = new Dictionary<string, List<Tuple<string, int>>>();

    public void AddEstacao(string nomeEstacao)
    {
        if (!estacoes.ContainsKey(nomeEstacao))
        {
            estacoes.Add(nomeEstacao, new List<Tuple<string, int>>());
        }
        else
        {
            Console.WriteLine("Estação já cadastrada!");
        }
    }
    public void RmEstacao(string nomeEstacao)
    {
        if (estacoes.ContainsKey(nomeEstacao))
        {
            estacoes.Remove(nomeEstacao);
        }
        else
        {
            Console.WriteLine("Estação não cadastrada!");
        }

    }
    public void ContectarEstacoes(string estacao1, string estacao2, int tempo)
    {
        if (estacoes.ContainsKey(estacao1) && estacoes.ContainsKey(estacao2))
        {
            estacoes[estacao1].Add(new Tuple<string, int>(estacao2, tempo));
            estacoes[estacao2].Add(new Tuple<string, int>(estacao1, tempo));
        }
        else
        {
            Console.WriteLine("Uma das estações não foi cadastrada!");
        }
    }
    public void DesconectarEstacoes(string estacao1, string estacao2)
    {
        if (estacoes.ContainsKey(estacao1))
        {
            estacoes[estacao1].RemoveAll(conexao => conexao.Item1 == estacao2);
            estacoes[estacao2].RemoveAll(conexao => conexao.Item1 == estacao1);
        }
        else
        {
            Console.WriteLine("Uma das estações não foi cadastrada!");
        }
    }
    public void ListarEstacoes()
    {
        Console.WriteLine(estacoes);
        foreach (var estacao in estacoes)
        {
            Console.WriteLine(estacao.Key);
            foreach (var conexoes in estacao.Value)
            {
                Console.WriteLine("--> " + conexoes.Item1 + " | Tempo:" + conexoes.Item2);
            }
            Console.WriteLine("===========");
        }
    }
}