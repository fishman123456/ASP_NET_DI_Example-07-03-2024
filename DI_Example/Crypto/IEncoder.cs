namespace DI_Example.Crypto
{
    // IEncoder - интерфейс алгоритма шифрования
    public interface IEncoder
    {
        // Encode - метод шиврования строки data
        string Encode(string data);

        // GetAlgorithmName - метод, возвращающий наименование алгоритма шивроания
        string GetAlgorithmName();
    }
}
