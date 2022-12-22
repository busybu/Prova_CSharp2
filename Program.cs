// Questão 1.Ao chegar em uma fila, um cliente pode decidir permanecer ou desistir se estiver impaciente.
// Você receberá um vetor de paciência onde a primeira posição do vetor é a paciência da primeira pessoa a chegar na fila.
// Assim a segunda posição do vetor é a paciência da segunda pessoa que chega na fila. E assim por diante.
// Se uma pessoa com paciência 2 chega numa fila com mais de 2 pessoas ela desiste e não entra na fila.
// Seu trabalho é escrever uma função que recebe esse vetor de paciência e retorna o tamanho final da fila.
// Exemplos:
// [2, 2, 0, 2, 2, 10]
// A fila começa vazia, a primeira pessoa chega com paciência 2 e como 0 < 2, ela entra na fila. Agora temos 1 pessoa na fila.
// A segunda pessoa também entra na fila. Agora temos 2 pessoas na fila.
// A terceira pessoa é impaciente e não entra na fila. Ainda temos 2 pessoas na fila.
// A quarta pessoa entra na fila, pois 2 (tamanho da fila) não é maior que 2 (paciência do cliente). Temoa 3 pessoas na fila.
// A quinta pessoa na fila tem paciência 2, ela não entra na fila pois a fila tem tamanho 3 maior que sua paciência 2.
// A última pessoa é muito paciente (10) e acaba entrando na fila. Resultado final 4 pessoas na fila.

int[] patience = new int[]
{
    0, 0, 1, 1, 2, 2, 3, 6, 8, 7, 9, 9
};

List<int> patienceList = new List<int>();
int tamFila = queueSize(patience);

int queueSize(int[] queue)
{
    int tamFila = 0;
    for (int i = 0; i < queue.Length; i++)
    {
        patienceList.Add(queue[i]);
       if(queue[i]>=tamFila)
       {
            tamFila++;
       }   
    }
    return tamFila;
}
Console.WriteLine($"A fila tem {tamFila} pessoas.");
// Questão 2.A respeito das pessoas da lista de paciência, use Linq para responder as seguintes perguntas:
// a) A maior paciência.
// b) A menor paciência.
// c) Quantos clientes tem mais de 2 de paciência.
// d) Qual grupo é maior? Os pacientes (>5), os impaciente (<2) ou os normais (2 a 5).
// Lembre-se de responder com Linq e não apenas o número.

Console.WriteLine($"O valor de maior paciência é: {patience.Max()}");
Console.WriteLine($"O valor da menor paciência é: {patience.Min()}");
Console.WriteLine($"A quantidade de clientes com mais de 2 de paciência é: {patience.Where(a => a > 2).Count()}");


var maior = patienceList
    .GroupBy(p =>
    {
        if (p < 2)
            return 0;
        else if (p > 5)
            return 2;
        return 1;
    })
    .OrderByDescending(g => g.Count())
    .FirstOrDefault().Key;

Console.Write("o Maior grupo é dos: ");
if(maior == 0){
    Console.Write("Impacientes");
}
else if(maior == 1){
    Console.Write("Pacientes");
}
else{
    Console.Write("Impacientes");
}
    
Console.WriteLine();
Console.WriteLine();

// Questão 3. Implemente a função demitir que faz o seguinte:
// Faz com que o Chefe do colaborador demitido se torne chefe de todos os colaboradores que o colaborador demitido era chefe.
// Exemplo
//     A
//     |          A é chefe de B e
//     B          B é chefe de C,
//    /|\         D e E.
//   C D E
// Quando B é demitido o seguinte acontece:
//     A
//    /|\         Agora A é chefe
//   C D E        de C, D e E.

Colaborador ChefaoMaster = new Colaborador("fulano", null);
Colaborador Chefinho = new Colaborador("fulaninho", ChefaoMaster);
Colaborador ProletariasC = new Colaborador("coitadoC", Chefinho);
Colaborador ProletariasD = new Colaborador("coitadoD", Chefinho);
Colaborador ProletariasE = new Colaborador("coitadoE", Chefinho);
Chefinho.Subordinados.Add(ProletariasC);
Chefinho.Subordinados.Add(ProletariasD);
Chefinho.Subordinados.Add(ProletariasE);


Chefinho.Demitir();

public class Colaborador
{
    public string Nome { get; set; }
    public Colaborador ?Chefe { get; set; }
    public List<Colaborador> Subordinados { get; set; } = new List<Colaborador>();

    public Colaborador(string nome, Colaborador chefe){
        Nome = nome;
        Chefe = chefe;
    }
    public void Demitir()
    {
        for(int i = 0; i < this.Subordinados.Count(); i++)
        {
            this.Subordinados[i].Chefe = this.Chefe;
            this.Chefe.Subordinados.Add(this.Subordinados[i]);
        }
    }
}