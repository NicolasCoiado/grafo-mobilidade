class GrafoEstacao()
{
    Dictionary<string, List<Conexoes>> estacoes = new Dictionary<string, List<Conexoes>>();

    public void AddEstacao(string nomeEstacao)
    {
        if (!estacoes.ContainsKey(nomeEstacao))
        {
            estacoes.Add(nomeEstacao, new List<Conexoes>());
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
            var conexao1 = new Conexoes();
            conexao1.EstacaoDestino = estacao1;
            conexao1.Tempo = tempo;

            var conexao2 = new Conexoes();
            conexao2.EstacaoDestino = estacao2;
            conexao2.Tempo = tempo;

            estacoes[estacao1].Add(conexao2);
            estacoes[estacao2].Add(conexao1);
        }
        else
        {
            Console.WriteLine("Uma das estações não foi cadastrada!");
        }
    }
    public void ListarEstacoes()
    {
        foreach (var estacao in estacoes)
        {
            Console.WriteLine(estacao.Key);
            foreach (var conexao in estacao.Value)
            {
                Console.WriteLine("-->" + conexao.EstacaoDestino + " | Tempo:" + conexao.Tempo);
            }
            Console.WriteLine(" ");
        }
    }
    public void Dijkstra(string eInicial, string eDestino)
    {
        if (!estacoes.ContainsKey(eInicial) || !estacoes.ContainsKey(eDestino))
        {
            Console.WriteLine("Uma das estações não foi cadastrada!");
            return;
        }

        Dictionary<string, int> custos = new Dictionary<string, int>();
        Dictionary<string, string> predecessores = new Dictionary<string, string>();
        HashSet<string> visitados = new HashSet<string>();

        foreach (var estacao in estacoes)
        {
            custos.Add(estacao.Key, int.MaxValue);
            predecessores.Add(estacao.Key, null);
        }

        custos[eInicial] = 0;

        while (visitados.Count < estacoes.Count)
        {
            string estacaoAtual = MenorCusto(custos, visitados);
            visitados.Add(estacaoAtual);

            foreach (var conexao in estacoes[estacaoAtual])
            {
                int novoCusto = custos[estacaoAtual] + conexao.Tempo;
                if (novoCusto < custos[conexao.EstacaoDestino])
                {
                    custos[conexao.EstacaoDestino] = novoCusto;
                    predecessores[conexao.EstacaoDestino] = estacaoAtual;
                }
            }
        }

        List<string> caminho = ReconstruirCaminho(predecessores, eDestino);
        caminho.Reverse();
        Console.WriteLine("Caminho mais curto de " + eInicial + " para " + eDestino + ":");
        foreach (var estacao in caminho)
        {
            Console.Write(estacao + " -> ");
        }
        Console.WriteLine("Chegada!");
        Console.WriteLine("Tempo total: " + custos[eDestino]);
    }
    private string MenorCusto(Dictionary<string, int> custos, HashSet<string> visitados)
    {
        int menorCusto = int.MaxValue;
        string estacaoMenorCusto = null;

        foreach (var estacao in custos)
        {
            if (!visitados.Contains(estacao.Key) && estacao.Value < menorCusto)
            {
                menorCusto = estacao.Value;
                estacaoMenorCusto = estacao.Key;
            }
        }

        return estacaoMenorCusto;
    }

    private List<string> ReconstruirCaminho(Dictionary<string, string> predecessores, string destino)
    {
        List<string> caminho = new List<string>();
        string estacaoAtual = destino;

        while (estacaoAtual != null)
        {
            caminho.Add(estacaoAtual);
            estacaoAtual = predecessores[estacaoAtual];
        }

        return caminho;
    }
}