class PagamentoApi{
    private id:number;
    private numParcela :number;
    private dataVenc: Date;
    private dataPag: Date;
    private numempre: number

    constructor(id:number,numP:number,dataVenc:Date,datap:Date,numEm:number){
        this.id=id;
        this.numParcela=numP;
        this.dataVenc=dataVenc;
        this.dataPag=datap;
        this.numempre=numEm;
    }
}