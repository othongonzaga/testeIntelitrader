//Teste 2 - Criptografia na rede do navio
//Como solicitado, o compilador online para executar os códigos é: https://www.onlinegdb.com/online_csharp_compiler

using System;

class Program
{
    static void Main()
    {
        // Mensagem criptografada
        string mensagemCriptografada = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

        // Remover espaços da mensagem criptografada
        mensagemCriptografada = mensagemCriptografada.Replace(" ", "");

        // Converter a string binária para um array de bytes
        byte[] bytesCriptografados = ConvertBinaryStringToByteArray(mensagemCriptografada);

        // Descriptografar a mensagem
        string mensagemDescriptografada = Descriptografar(bytesCriptografados);

        // Exibir a mensagem descriptografada
        Console.WriteLine("Mensagem Descriptografada: " + mensagemDescriptografada);
    }

    // Método para converter uma string binária em um array de bytes
    static byte[] ConvertBinaryStringToByteArray(string binaryString)
    {
        int length = binaryString.Length;
        byte[] bytes = new byte[length / 8];

        for (int i = 0; i < length; i += 8)
        {
            string byteString = binaryString.Substring(i, 8);
            bytes[i / 8] = Convert.ToByte(byteString, 2);
        }

        return bytes;
    }

    // Método para descriptografar a mensagem
    static string Descriptografar(byte[] bytesCriptografados)
    {
        for (int i = 0; i < bytesCriptografados.Length; i++)
        {
            // Inverter os dois últimos bits de cada byte
            bytesCriptografados[i] = (byte)(bytesCriptografados[i] ^ 0x03);

            // Trocar os 4 bits iniciais com os próximos 4 bits
            bytesCriptografados[i] = (byte)(((bytesCriptografados[i] & 0xF0) >> 4) | ((bytesCriptografados[i] & 0x0F) << 4));
        }

        // Converter os bytes descriptografados para uma string ASCII
        string mensagemDescriptografada = System.Text.Encoding.ASCII.GetString(bytesCriptografados);

        return mensagemDescriptografada;
    }
}
