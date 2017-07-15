angular.module("listaTelefonica").controller("listaTelefonicaCtrl", function ($scope, $filter, contatosAPI, operadorasAPI, serialGenerator) {

    $scope.app = "Lista Telefonica";

    $scope.contatos = [];
    $scope.operadoras = [];

    var carregarContatos = function () {

        contatosAPI.getContatos()
          .then(function (response) {
              $scope.contatos = response.data;
          }, function () {
              $scope.message = "Aconteceu um problema: " + response;
          });
    };

    var carregaOperadoras = function () {
        operadorasAPI.getOperadoras()
            .then(function (response) {
                $scope.operadoras = response.data;
            }, function () {
                $scope.message = "Aconteceu um problema: " + response;
            });
    };

    carregarContatos();
    carregaOperadoras();
    console.log('rrrrrr');
    console.log(serialGenerator.generate());


    $scope.adicionarContato = function (contato) {

        contato.serial = serialGenerator.generate();
        contato.data = new Date();
        contato.OperadoraId = contato.Operadora.Id;
        contato.Operadora = null;

        contatosAPI.saveContato(contato)
            .then(function (response) {

                carregarContatos();
                carregaOperadoras();

                $scope.contato = {};
                $scope.contatoForm.$setPristine();

            }, function () {
                $scope.message = "Aconteceu um problema: " + response;
            })
    };

    $scope.apagarContatos = function (contatos) {

        var contatos = contatos.filter(function (contato) {
            if (contato.selecionado) return contato;
        });

        $http.post("/api/v1/public/deleteContato/", contatos)
            .then(function (response) {
                carregarContatos();
            }, function (response) {
                $scope.message = "Aconteceu um problema: " + response.data;
            });
    };

    $scope.isContatoSelecionado = function (contatos) {
        return contatos.some(function (contato) {
            return contato.selecionado;
        });
    };

    $scope.ordernarPor = function (campo) {
        $scope.criterioDeOrdenacao = campo;
        $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
    };
});