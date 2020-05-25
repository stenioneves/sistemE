
class EmprestimoApi
{   private id:number;
    private valorSolicitado:number;
    private qtd:number;
    private observacao:string;
    private nome:string;
    private descricao:string;
    private autorizado:string;

    constructor(id:number,valor:number,qtda:number,obs:string,nome:string,desc:string,au:string)
    {  
        this.id=id;
        this.valorSolicitado=valor;
        this.qtd=qtda;
        this.observacao=obs;
        this.nome=nome;
        this.descricao=desc;
        this.autorizado=au;


    }

}