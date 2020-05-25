/// <reference path="EmprestimoApi.ts" />
/// <reference path="PagamentoApi.ts" />
//Inicio de variaves
var emprestimos = [];
var pagamentoConsulta = [];
//Pegar os dados de emprestimo da webservice
var CarregarEmprestimo = function (nome) {
    var url = "https://localhost:5001/api/dash/emprestimo";
    if (nome != null)
        url = "https://localhost:5001/api/dash/emprestimo/?nome=" + nome;
    fetch(url)
        .then(function (resposta) { return resposta.json(); }) //converte para json
        .then(function (data) {
        data.forEach(function (item) {
            var empretimo = new EmprestimoApi(item.id, item.valorSolicitado, item.qtd, item.observacao, item.nome, item.descricao, item.autorizado);
            emprestimos.push(empretimo); //Colocar os osbjetos no array
        });
    });
};
//Exibe redereiza a tabela com os dados
var MostrarEmprestimos = function () {
    var html = "";
    html += '<table class="table table-sm table-responsive ">';
    html += '<thead class="thead-light">';
    html += '<tr >';
    html += '<th >Código</th>';
    html += '<th>Valor R$:</th>';
    html += '<th>Num Parc</th>';
    html += '<th>Observação</th>';
    html += '<th>Solicitante</th>';
    html += '<th>Status</th>';
    html += '<th>Autorizador</th>';
    html += '<th>Ação</th>';
    html += '</tr>';
    html += '</thead>';
    html += '<tbody>';
    emprestimos.forEach(function (emp) {
        html += '<tr>';
        html += "<td>" + emp.id + " </td>";
        html += "<td>" + emp.valorSolicitado.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' }) + "</td>"; //conversão para moeda
        html += "<td>" + emp.qtd + "</td>";
        html += "<td>" + emp.observacao + "</td>";
        html += "<td>" + emp.nome + "</td>";
        html += "<td>" + emp.descricao + "</td>";
        html += "<td>" + emp.autorizado + "</td>";
        html += "<td><button type=\"button\" class=\"btn btn-outline-success\" onclick=\"PegarPagamento(" + emp.id + "," + emp.qtd + ")\">Mostrar Pagamento</button></td>"; //passa o id e parcela   
        html += '</tr>';
    });
    html += "</tbody>";
    html += "</table>";
    $("#divtable").html(html);
};
//consulta os pagamentos/parcelas na webservice associado ao id de emprestimo
var PegarPagamento = function (id, nup) {
    var url = "https://localhost:5001/api/dash/parcelas/?id=" + id;
    fetch(url)
        .then(function (dados) { return dados.json(); })
        .then(function (data) {
        if (data.length == [].length) // Verifica se o array retornou vazio e exibe alerta
         {
            $("#spanErro").html('<div class="alert alert-danger alert-dismissible fade show" role="alert"> CR01-Não existem parcelas associadas a esse emprestimo!' +
                '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
                '<span aria-hidden="true">&times;</span></button></div>');
        }
        data.forEach(function (item) {
            var pag = new PagamentoApi(item.id, item.numParcela, item.dataVenc, item.dataPag, item.idemprestimo);
            pagamentoConsulta.push(pag);
        });
    })
        .catch(function (erro) {
        alert(" R01- Erro na requsi\u00E7\u00E3o!");
        console.log(erro);
    });
    var parHtml = "";
    parHtml += '<div class="jumbotron">';
    parHtml += '<h3 class="text-center text-uppercase">Pagamentos do emprestimo ' + id + '</h3>';
    parHtml += '<div id="grafico"></div>';
    parHtml += '<table class="table">';
    parHtml += "<caption>Lista de pagamentos  </caption>";
    parHtml += '<thead class="thead-light">';
    parHtml += '<tr >';
    parHtml += '<th>Código</th>';
    parHtml += '<th>Número Parcela</th>';
    parHtml += '<th>Data de vencimento</th>';
    parHtml += '<th>Data Pagamento</th>';
    parHtml += '<th>Situação</th>';
    parHtml += '</tr>';
    parHtml += '</thead>';
    parHtml += '<tbody id="testez">';
    parHtml += '</tbody>';
    parHtml += '</table>';
    parHtml += "<button class=\"btn btn-md btn-primary\" onclick=\"exibirParcela(" + nup + ")\">Atualizar informa\u00E7\u00E3o</button> "; //passa o numero total de parcelas
    parHtml += "</div>";
    $("#parceladiv").html(parHtml);
};
var pequisaEmp = $("#pequisaEmp");
pequisaEmp.focusout(function () {
    var nome = pequisaEmp.val();
    CarregarEmprestimo(nome);
    emprestimos = [];
});
//# sourceMappingURL=ServicoApi.js.map