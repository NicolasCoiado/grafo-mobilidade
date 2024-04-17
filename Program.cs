GrafoEstacao estacoesSP = new GrafoEstacao();

estacoesSP.AddEstacao("Corinthians - Itaquera");
estacoesSP.AddEstacao("Arthur Alvim");
estacoesSP.AddEstacao("Patriarca - Vila Ré");
estacoesSP.AddEstacao("Guilhermina Esperança");
estacoesSP.AddEstacao("Vila Matilde");
estacoesSP.AddEstacao("Penha - Lojas Besni");
estacoesSP.AddEstacao("Carrão -  Assaí Atacadista");
estacoesSP.AddEstacao("Tatuapé");
estacoesSP.AddEstacao("Belém");
estacoesSP.AddEstacao("Bresser - Mooca");
estacoesSP.AddEstacao("Brás");
estacoesSP.AddEstacao("Pedro II");
estacoesSP.AddEstacao("Sé");

//Linha Vermelha do metrô:
estacoesSP.ContectarEstacoes("Corinthians - Itaquera", "Arthur Alvim", 2);
estacoesSP.ContectarEstacoes("Arthur Alvim", "Patriarca - Vila Ré", 2);
estacoesSP.ContectarEstacoes("Patriarca - Vila Ré", "Guilhermina Esperança", 2);
estacoesSP.ContectarEstacoes("Guilhermina Esperança", "Vila Matilde", 2);
estacoesSP.ContectarEstacoes("Vila Matilde", "Penha - Lojas Besni", 2);
estacoesSP.ContectarEstacoes("Penha - Lojas Besni", "Carrão -  Assaí Atacadista", 5);
estacoesSP.ContectarEstacoes("Carrão -  Assaí Atacadista", "Tatuapé", 5);
estacoesSP.ContectarEstacoes("Tatuapé", "Belém", 3);
estacoesSP.ContectarEstacoes("Belém", "Bresser - Mooca", 3);
estacoesSP.ContectarEstacoes("Bresser - Mooca", "Brás", 3);
estacoesSP.ContectarEstacoes("Brás", "Pedro II", 3);
estacoesSP.ContectarEstacoes("Pedro II", "Sé", 3);

//Linha Coral da CPTM:
estacoesSP.ContectarEstacoes("Corinthians - Itaquera", "Tatuapé", 20);
estacoesSP.ContectarEstacoes("Tatuapé", "Brás", 10);
estacoesSP.ContectarEstacoes("Brás", "Sé", 5);

estacoesSP.ListarEstacoes();