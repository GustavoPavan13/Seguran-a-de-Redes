using System.Reflection.Metadata;
using SegurançadeRedes.Models;

CifradeFeistel cifradeFeistel = new CifradeFeistel();

Console.WriteLine("Digite abaixo o codigo de 8 bits a ser cifrado:");
int [] bloco = new int [8];
for(int i = 0; i<bloco.Length;i++){
    bloco [i] = int.Parse(Console.ReadLine());
}


Console.WriteLine("Digite abaixo a primeira chave de 4 bits:");
int [] chave1 = new int [4];
for(int i = 0; i<chave1.Length;i++){
    chave1 [i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Digite abaixo a primeira chave de 4 bits:");
int [] chave2 = new int [4];
for(int i = 0; i<chave2.Length;i++){
    chave2 [i] = int.Parse(Console.ReadLine());
}

int [] criptografado = cifradeFeistel.Criptografar(bloco,chave1,chave2);
int [] resultado =cifradeFeistel.Descriptografar(criptografado, chave1,chave2);
Console.WriteLine("O codigo criptografado é");
for(int i =0; i<criptografado.Length;i++){
    Console.Write(criptografado[i]);
}
Console.WriteLine(" ");
Console.WriteLine("O codigo descriptografado é");
for(int i =0; i<resultado.Length;i++){
    
    Console.Write(resultado[i]);
}