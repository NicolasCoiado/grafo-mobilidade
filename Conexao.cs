class Conexoes()
{
    private string _estacaoDestino;
    private int _tempo;

    public string EstacaoDestino
    {
        get => _estacaoDestino;
        set => _estacaoDestino = value;
    }

    public int Tempo
    {
        get => _tempo;
        set => _tempo = value;
    }
}