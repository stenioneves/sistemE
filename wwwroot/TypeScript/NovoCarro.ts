/// <reference path="Carro.ts" />

let MostrarCarro =()=>
{ let novoCarro= new Carro("Ferrari");
 document.getElementById("divmensagem").innerHTML=novoCarro.CriarNomeCarro();
 let novoCarro2 = new Carro("Posher");
 $("#divmensagem2").html(novoCarro2.CriarNomeCarro()); //Jquery
 let novoTrator = new Trator("CAT 9365");
 novoTrator.pesso= 100000

 $("#divmensagem3").html( `${novoTrator.CriarNomeCarro()}  ${novoTrator.pesso}`)

}