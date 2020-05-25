// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

const MenuRota =(sel)=>{
    
    switch (sel) {
        case 0:
            window.location.href='./beneficiarios'
            break;
        case 1:
            window.location.href='./Emprestimos'
            break;
        case 2:
            window.location.href='./Pagamentos'
            break
        case 3:
            window.location.href='./Situacoes'
            break;        

    
        default:
            window.alert("Erro na solicitação")
            break;
    }
   
}
angular.module("Emprestimos",[]);
angular.module("Emprestimos").controller("CtrlEmprestimos", function($scope,$http)
{
    $scope.listar= function(){
        $http.get('./api/dash').then(function(response){
            $scope.lemprestimos=response.data.records});
    };
    $scope.listar();
}

)