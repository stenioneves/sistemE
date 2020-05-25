/// <reference path="Carro.ts" />
var MostrarCarro = function () {
    var novoCarro = new Carro("Ferrari");
    document.getElementById("divmensagem").innerHTML = novoCarro.CriarNomeCarro();
    var novoCarro2 = new Carro("Posher");
    $("#divmensagem2").html(novoCarro2.CriarNomeCarro()); //Jquery
    var novoTrator = new Trator("CAT 9365");
    novoTrator.pesso = 100000;
    $("#divmensagem3").html(novoTrator.CriarNomeCarro() + "  " + novoTrator.pesso);
};
//# sourceMappingURL=NovoCarro.js.map