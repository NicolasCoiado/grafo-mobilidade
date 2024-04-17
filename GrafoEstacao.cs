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
    // public void DesconectarEstacoes(string estacao1, string estacao2)
    // {
    //     if (estacoes.ContainsKey(estacao1))
    //     {
    //         estacoes[estacao1].RemoveAll(conexao => conexao.Item1 == estacao2);
    //         estacoes[estacao2].RemoveAll(conexao => conexao.Item1 == estacao1);
    //     }
    //     else
    //     {
    //         Console.WriteLine("Uma das estações não foi cadastrada!");
    //     }
    // }
    public void ListarEstacoes()
    {
        Console.WriteLine(estacoes);
        foreach (var estacao in estacoes)
        {
            foreach (var conexoes in estacao.Value)
            {
                Console.WriteLine(conexoes);
            }
        }

        // foreach (var estacao in estacoes)
        // {
        //     Console.WriteLine(estacao.Key);
        //     foreach (var conexoes in estacao.Value)
        //     {
        //         Console.WriteLine("--> " + conexoes.Item1 + " | Tempo:" + conexoes.Item2);
        //     }
        //     Console.WriteLine("===========");
        // }
    }

    public void Djikstra(string eInicial, string eDestino)
    {
        Dictionary<string, List<Tuple<string, int, string>>> tempos = new Dictionary<string, List<Tuple<string, int, string>>>();

        if (estacoes.ContainsKey(eInicial) && estacoes.ContainsKey(eDestino))
        {
            foreach (var estacao in estacoes[eInicial])
            {
                Console.WriteLine(estacao.Item1);
                Console.WriteLine(estacao.Item2);
                // tempos.Add(new Tuple<string, int, string>(estacao, estacao.Item2));
            }
        }
        else
        {
            Console.WriteLine("Uma das estações não foi cadastrada!");
        }
    }
}