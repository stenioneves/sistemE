class Carro
{
    private nome:string;

    constructor(nomeCarro:string){
        this.nome= nomeCarro;
    }

    public CriarNomeCarro():string{
        return `Seu carro e : ${this.nome}`;
    }

}

class Trator extends Carro
{
    pesso:number;
}